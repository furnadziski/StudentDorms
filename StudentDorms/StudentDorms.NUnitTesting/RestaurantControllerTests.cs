using StudentDorms.API.Controllers;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Implementations;
using StudentDorms.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;
using StudentDorms.Models.GridModels;

namespace CoMS.NUnitTesting
{
    public class RestaurantControllerTests
    {
        private DatabaseContext _dbContext;
        private IProcedureRepository<RestaurantGridModel> _procedureRepository;
        private IRestaurantRepository _restaurantRepository;
        private IRestaurantService _restaurantService;
        private RestaurantController _restaurantController;

        [SetUp]
        public void Setup()
        {
            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();

            _procedureRepository = new ProcedureRepository<RestaurantGridModel>(_dbContext);
            _restaurantRepository = new RestaurantRepository(_dbContext);
            _restaurantService = new RestaurantService(_procedureRepository, _restaurantRepository);
            _restaurantController = new RestaurantController(_restaurantService);
        }

        [Test]
        public void TestMethod()
        {
            var result = _restaurantController.GetRestaurantsForGrid(null);
            Assert.NotNull(result.Value);
        }
    }
}