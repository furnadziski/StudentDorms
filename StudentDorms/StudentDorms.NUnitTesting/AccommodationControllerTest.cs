using NUnit.Framework;
using StudentDorms.API.Controllers;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Services.Implementations;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.NUnitTesting
{
    public class AccommodationControllerTest
    {
        private DatabaseContext _dbContext;
        private IAccommodationRepository _accommodationRepository;
        private IAccommodationService _accommodationService;
        private AccommodationController _accommodationController;
        private ProcedureRepository<AccommodationGridModel> _procedureRepositoryAccommodation;

        [SetUp]
        public void Setup()
        {

            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();
            _accommodationRepository = new AccommodationRepository(_dbContext);
            _procedureRepositoryAccommodation = new ProcedureRepository<AccommodationGridModel>(_dbContext);
            _accommodationService = new AccommodationService(_procedureRepositoryAccommodation, _accommodationRepository);
            _accommodationController = new AccommodationController(_accommodationService);
        }

        [Test]
        public void GetAccommodationsForGridTest()
        {
            AccommodationSearchModel model = new AccommodationSearchModel();
            model.RoomSearchText = "";
            model.BlockId = null;
            model.CapacitySearch = null;
            model.HasFreeSpaceOnly = 1;
            model.StudentDormId = 1;
            model.Year = 2024;
            model.Userid = null;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _accommodationController.GetAccommodationsForGrid(model);
            Assert.NotNull(result.Value);
        }


    }
}
