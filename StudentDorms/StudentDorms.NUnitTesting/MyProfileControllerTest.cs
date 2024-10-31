using NUnit.Framework;
using StudentDorms.API.Controllers;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.XmlModels;
using StudentDorms.Services.Implementations;
using StudentDorms.Services.Interfaces;
using System;

namespace StudentDorms.NUnitTesting
{
    public class MyProfileControllerTest {

        private DatabaseContext _dbContext;
        private IMealRepository _mealRepository;
        private IMealService _mealService;
        private IUserRepository _userRepository;
        private IUserService _userService;
        private MyProfileController _myProfileController;
        private MealController _mealController;
        private IWeeklyMealRepository _weeklyMealRepository;
        private IMealCategoryRepository _mealCategoryRepository;
        private ProcedureRepository<MyProfileGridModel> _procedureRepositoryMyProfile;
        private ProcedureRepository<UserGridModel> _procedureRepositoryUser;
        private ProcedureRepository<ScalarString> _storedProcedureScalar;
        private ProcedureRepository<MealCategoryGridModel> _procedureRepositoryMealCategory;
        private ProcedureRepository<MealGridModel> _procedureRepositoryMeal;


        [SetUp]
        public void Setup()
        {
            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();
            _mealCategoryRepository = new MealCategoryRepository(_dbContext);
            _procedureRepositoryMealCategory = new ProcedureRepository<MealCategoryGridModel>(_dbContext);
            _mealRepository = new MealRepository(_dbContext);
            _procedureRepositoryMeal = new ProcedureRepository<MealGridModel>(_dbContext);
            _storedProcedureScalar = new ProcedureRepository<ScalarString>(_dbContext);
            _weeklyMealRepository = new WeeklyMealRepository(_dbContext);
            _mealService = new MealService(_procedureRepositoryMealCategory, _mealCategoryRepository, _procedureRepositoryMeal, 
            _mealRepository, _storedProcedureScalar,_weeklyMealRepository);
            _userRepository = new UserRepository(_dbContext);
            _procedureRepositoryMyProfile = new ProcedureRepository<MyProfileGridModel>(_dbContext);
            _userService = new UserService(_procedureRepositoryUser, _userRepository, _procedureRepositoryMyProfile);
            _mealController = new MealController(_mealService);
            _myProfileController = new MyProfileController(_mealService,_userService);
        }

        [Test]
        public void FilterMealScheduleTest()
        {

            FilterMealSearchModel model = new FilterMealSearchModel();
            model.StartDateTime = new DateTime(2024, 10, 15, 00, 00, 0);
            model.EndDateTime = new DateTime(2024, 10, 21, 00, 00, 0);
            var result = _mealController.FilterMealSchedule(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void GetUserForMyProfileTest()
        {
            MyProfileSearchModel model = new MyProfileSearchModel();
            model.UserId = 1;

            var result = _myProfileController.GetUserForMyProfile(model);
            Assert.NotNull(result.Value);
        }

    }

}

