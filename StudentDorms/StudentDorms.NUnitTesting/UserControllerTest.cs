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
using System.Collections.Generic;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.NUnitTesting
{
    public class UserControllerTests
    {
        private DatabaseContext _dbContext;
        private IProcedureRepository<UserGridModel> _procedureRepository;
        private IUserRepository _userRepository;
        private IUserService _userService;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
          
            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();

            _procedureRepository = new ProcedureRepository<UserGridModel>(_dbContext);
            _userRepository = new UserRepository(_dbContext);
            _userService = new UserService(_procedureRepository,_userRepository);
            _userController = new UserController(_userService);
        }

        [Test]
        public void GetUsersForGridTest()
        {
            UserSearchModel model = new UserSearchModel();
            model.SearchText = ""; 
            model.RoleId =null;
            model.GenderId = 2;
            model.IsActive = 1;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 2;
            model.RowsPerPage = 2;
            var result = _userController.GetUsersForGrid(model);
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
            
           
            var result = _userController.CreateUser(model);
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
           // dropdownList.Add(newItem2);

            UserCreateUpdateModel model = new UserCreateUpdateModel();
             model.Id = 12;
             model.Roles = dropdownList;
             model.FirstName = "Darko";
             model.LastName = "Tester";
             model.Email = "2323@gmail.com";
             model.Username = "Tester";
             model.GenderId = 1;
             model.IsActive = false;
           
            var result = _userController.UpdateUser(model);
            Assert.NotNull(result.Value);


        }
    }
}