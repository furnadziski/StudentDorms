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

        private IGenderService _genderService;
        private IGenderRepository _genderRepository;
        private IStudentDormRepository _studentDormRepository;
        private IStudentDormService _studentDormService;
        private IUserRepository _userRepository;
        private IUserService _userService;
        private ConfigController _configController;
        private ProcedureRepository<UserGridModel> _procedureRepositoryUser;
        private ProcedureRepository<StudentDormGridModel> _procedureRepositoryStudentDorm;



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
            _configController = new ConfigController(_userService, _studentDormService, _sharedService);

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


    }
}
