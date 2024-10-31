using NUnit.Framework;
using StudentDorms.API.Controllers;
using StudentDorms.Data.Context;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.CreateUpdateModels;
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
    public class AnnualAccommodationControllerTest
    {
        private DatabaseContext _dbContext;
        private IAnnualAccommodationRepository _accommodationRepository;
        private IAnnualAccommodationService _accommodationService;
        private AnnualAccommodationController _accommodationController;
        private ProcedureRepository<AccommodationGridModel> _procedureRepositoryAccommodation;

        [SetUp]
        public void Setup()
        {

            Configuration.ConfigureDependencies.InitializeConfigurations();
            _dbContext = Configuration.ConfigureDependencies.GetDbContext();
            _accommodationRepository = new AnnualAccommodationRepository(_dbContext);
            _procedureRepositoryAccommodation = new ProcedureRepository<AccommodationGridModel>(_dbContext);
            _accommodationService = new AnnualAccommodationService(_procedureRepositoryAccommodation, _accommodationRepository);
            _accommodationController = new AnnualAccommodationController(_accommodationService);
        }

        [Test]
        public void GetAccommodationsForGridTest()
        {
            AnnualAccommodationSearchModel model = new AnnualAccommodationSearchModel();
            model.RoomSearchText = "";
            model.BlockId = null;
            model.CapacitySearch = null;
            model.HasFreeSpaceOnly = false;
            model.StudentDormId = 1;
            model.Year = 2024;
            model.Userid = null;
            model.OrderColumn = "";
            model.OrderDirection = "ASC";
            model.PageNumber = 1;
            model.RowsPerPage = 10;
            var result = _accommodationController.GetAnnualAccommodationsForGrid(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void UpdateAccommodationTest()
        {
            AccommodationCreateUpdateModel model = new AccommodationCreateUpdateModel();
            model.Id = 1;
            model.Year = 2023;
            model.RoomId = 4;
           
            var result = _accommodationController.UpdateAccommodation(model);
            Assert.NotNull(result.Value);
        }
    }
}
