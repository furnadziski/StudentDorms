using NUnit.Framework;
using StudentDorms.API.Controllers;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Implementations;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.NUnitTesting.Extensions
{
    public class ConfigControllerTest
    {
        private DatabaseContext _dbContext;
        private IRoleRepository _roleRepository;
        private IRoleService _roleService;
        private ISharedService _sharedService;
        private IBlockService _blockService;
        private IBlockRepository _blockRepository;
        private IGenderService _genderService;
        private IGenderRepository _genderRepository;
        private IStudentDormRepository _studentDormRepository;
        private IStudentDormService _studentDormService;
        private IUserRepository _userRepository;
        private IUserService _userService;
        private IRoomRepository _roomRepository;
        private IRoomService _roomService;
        private IMealCategoryRepository _mealCategoryRepository;
        private IMealRepository _mealRepository;
        private IMealService _mealService;
        private ConfigController _configController;
        private ProcedureRepository<UserGridModel> _procedureRepositoryUser;
        private ProcedureRepository<StudentDormGridModel> _procedureRepositoryStudentDorm;
        private ProcedureRepository<BlockGridModel> _procedureRepositoryBlock;
        private ProcedureRepository<RoomGridModel> _procedureRepositoryRoom;
        private ProcedureRepository<MealCategoryGridModel> _procedureRepositoryMealCategory;
        private ProcedureRepository<MealGridModel> _procedureRepositoryMeal;



        [SetUp]
        public void Setup()
        {

            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();
            _roleRepository = new RoleRepository(_dbContext);
            _roleService = new RoleService(_roleRepository);
            _genderRepository = new GenderRepository(_dbContext);
            _genderService = new GenderService(_genderRepository);
            _studentDormRepository = new StudentDormRepository(_dbContext);
            _procedureRepositoryUser = new ProcedureRepository<UserGridModel>(_dbContext);
            _procedureRepositoryStudentDorm = new ProcedureRepository<StudentDormGridModel>(_dbContext);
            _sharedService = new SharedService();
            _studentDormService = new StudentDormService(_procedureRepositoryStudentDorm, _studentDormRepository);
            _userRepository = new UserRepository(_dbContext);
            _userService = new UserService(_procedureRepositoryUser, _userRepository);
            _blockRepository = new BlockRepository(_dbContext);
            _procedureRepositoryBlock = new ProcedureRepository<BlockGridModel>(_dbContext);
            _blockService = new BlockService(_procedureRepositoryBlock, _blockRepository);
            _roomRepository = new RoomRepository(_dbContext);
            _procedureRepositoryRoom = new ProcedureRepository<RoomGridModel>(_dbContext);
            _roomService = new RoomService(_roomRepository,_procedureRepositoryRoom);
            _mealCategoryRepository = new MealCategoryRepository(_dbContext);
            _procedureRepositoryMealCategory = new ProcedureRepository<MealCategoryGridModel>(_dbContext);
            _mealRepository = new MealRepository(_dbContext);
            _procedureRepositoryMeal = new ProcedureRepository<MealGridModel>(_dbContext);
            _mealService = new MealService(_procedureRepositoryMealCategory, _mealCategoryRepository,_procedureRepositoryMeal, _mealRepository);
            _configController = new ConfigController(_userService, _studentDormService, _sharedService, _blockService,_roomService,_mealService);

        }

        [Test]
        public void RoleForDropDownTest()
        {
            var result = _configController.GetRolesForDropdown();
        }

        [Test]
        public void GenderForDropDownTest()
        {
            var result = _configController.GetGendersForDropdown();
        }

        [Test]
        public void GetUsersForGridTest()
        {
            UserSearchModel model = new UserSearchModel();
            model.SearchText = "";
            model.RoleId = null;
            model.GenderId = 2;
            model.IsActive = 1;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 2;
            model.RowsPerPage = 2;
            var result = _configController.GetUsersForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void CreateUserTest()
        {
            List<DropdownViewModel<int>> dropdownList = new List<DropdownViewModel<int>>();

            DropdownViewModel<int> newItem1 = new DropdownViewModel<int>();
            newItem1.Id = 1;
            newItem1.Title = "Administrator";
            DropdownViewModel<int> newItem2 = new DropdownViewModel<int>();
            newItem2.Id = 2;
            newItem2.Title = "Student";
            dropdownList.Add(newItem1);
            dropdownList.Add(newItem2);

            UserCreateUpdateModel model = new UserCreateUpdateModel();
            model.Email = "sdasd@gmail.com";
            model.FirstName = "Petar";
            model.LastName = "Furnadjiski";
            model.Username = "Pepo";
            model.GenderId = 1;
            model.IsActive = true;
            model.Roles = dropdownList;

            var result = _configController.CreateUser(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void UpdateUserTest()
        {
            List<DropdownViewModel<int>> dropdownList = new List<DropdownViewModel<int>>();

            DropdownViewModel<int> newItem1 = new DropdownViewModel<int>();
            newItem1.Id = 1;
            newItem1.Title = "Administrator";
            DropdownViewModel<int> newItem2 = new DropdownViewModel<int>();
            newItem2.Id = 2;
            newItem2.Title = "Student";

            dropdownList.Add(newItem1);

            UserCreateUpdateModel model = new UserCreateUpdateModel();
            model.Id = 12;
            model.Roles = dropdownList;
            model.FirstName = "Ddfgarko";
            model.LastName = "Tefdgdster";
            model.Email = "2323fgfdg@gmail.com";
            model.Username = "Tester";
            model.GenderId = 1;
            model.IsActive = false;

            var result = _configController.UpdateUser(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void GetStudentDormsForGridTest()
        {
            StudentDormSearchModel model = new StudentDormSearchModel();
            model.SearchText = "";
            model.OrderColumn = "ORDER";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _configController.GetStudentDormsForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void GetBooleanOptionsForDropdown()
        {
            var result = _configController.GetBooleanOptionsForDropdown();
        }

        [Test]
        public void CreateStudentDormTest()
        {
            StudentDormCreateUpdateModel model = new StudentDormCreateUpdateModel();

            model.Name = "Стив Наумов(Бараки)";
            model.Order = 4;

            var result = _configController.CreateStudentDorm(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void UpdateStudentDormTest()
        {
            StudentDormCreateUpdateModel model = new StudentDormCreateUpdateModel();
            model.Id = 1;
            model.Name = "Гоце Делчев";
            model.Order = 1;
            var result = _configController.UpdateStudentDorm(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void DeleteStudentDormTest() {

            IntSearchModel intSearchModel = new IntSearchModel();
            intSearchModel.Id = 6;
            var result = _configController.DeleteStudentDormById(intSearchModel);

        }

        [Test]
        public void GetBlocksForGridTest()
        {
            BlockSearchModel model = new BlockSearchModel();
            model.SearchText="";
            model.StudentDormId = 1;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _configController.GetBlocksForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void CreateBlockTest()
        {
            BlockCreateUpdateModel model = new BlockCreateUpdateModel();
            model.Name = "BlokTfdest22";
            model.Order = 10;
            model.StudentDormId = 2;

            var result = _configController.CreateBlock(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void UpdateBlockTest()
        {
            BlockCreateUpdateModel model = new BlockCreateUpdateModel();
            model.Id = 11;
            model.Name = "dddddddddddd";
            model.Order = 4;
            model.StudentDormId = 1;

            var result = _configController.UpdateBlock(model);
            Assert.NotNull(result.Value);

        }
        [Test]
        public void DeleteBlockTest()
        {

            IntSearchModel intSearchModel = new IntSearchModel();
            intSearchModel.Id = 5;
            var result = _configController.DeleteBlockById(intSearchModel);

        }

        [Test]
        public void GetRoomsForGridTest()
        {
            RoomSearchModel model = new RoomSearchModel();
            model.SearchText = "";
            model.BlockId = 1;
            model.StudentDormId = 1;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _configController.GetRoomsForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void CreateRoomTest()
        {
            RoomCreateUpdateModel model = new RoomCreateUpdateModel();
            model.BlockId = 1;
            model.Capacity = 4;
            model.IsActive = true;
            model.Order = 5;
            model.RoomNo = "TestCreate";

            var result = _configController.CreateRoom(model);
            Assert.NotNull(result.Value);
        }
        [Test]
        public void UpdateRoomTest()
        {
            RoomCreateUpdateModel model = new RoomCreateUpdateModel();
            model.Id = 1;
            model.BlockId = 2;
            model.RoomNo = "2024";
            model.Capacity = 2;
            model.IsActive = false;
            model.Order = 1;
            var result = _configController.UpdateRoom(model);
            Assert.NotNull(result.Value);
        }
        [Test]
        public void DeleteRoomTest()
        {
            IntSearchModel intSearchModel = new IntSearchModel();
            intSearchModel.Id = 2;
            var result = _configController.DeleteRoomById(intSearchModel);

        }

        [Test]
        public void GetMealCategoriesForGridTest()
        {
            MealCategorySearchModel model = new MealCategorySearchModel();
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _configController.GetMealCategoriesForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void GetMealsForGridTest()
        {
            MealSearchModel model = new MealSearchModel();
            model.SearchText = "";
            model.MealCategoryId = 1;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _configController.GetMealsForGrid(model);
            Assert.NotNull(result.Value);
        }
    }
}
