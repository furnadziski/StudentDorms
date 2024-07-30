using NUnit.Framework;
using StudentDorms.API.Controllers;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Services.Implementations;
using StudentDorms.Services.Interfaces;
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
            _userService = new UserService(_procedureRepository);
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
    }
}