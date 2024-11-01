﻿using NUnit.Framework;
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
using System.Collections.Generic;


namespace StudentDorms.NUnitTesting
{
    public class MealControllerTest
    {
        private DatabaseContext _dbContext;
        private IMealRepository _mealRepository;

        private IMealService _mealService;

        private IWeeklyMealRepository _weeklyMealRepository;

        private MealController _mealController;
        private IMealCategoryRepository _mealCategoryRepository;
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
            _mealService = new MealService(_procedureRepositoryMealCategory, _mealCategoryRepository, _procedureRepositoryMeal, _mealRepository, _storedProcedureScalar, _weeklyMealRepository);
            _mealController = new MealController(_mealService);
        }

        [Test]
        public void FilterMealScheduleTest()
        {

            FilterMealSearchModel model = new FilterMealSearchModel();
            model.StartDateTime = new DateTime(2024, 8, 5, 00, 00, 0);
            model.EndDateTime = new DateTime(2024, 8, 12, 00, 00, 0);
            var result = _mealController.FilterMealSchedule(model);
            Assert.NotNull(result.Value);
        }

        [Test]
        public void FilterMealVotingTest()
        {

            FilterMealVotingSearchModel model = new FilterMealVotingSearchModel();
            model.UserId = 1;
            var result = _mealController.FilterMealVoting(model);
            Assert.NotNull(result.Value);
        }
        [Test]
        public void SaveMealVoting()
        {

            List<MealVoteGridModel> mealVoteGridModels = new List<MealVoteGridModel>();
            MealVoteGridModel newitem1 = new MealVoteGridModel();
          
            newitem1.Date= new DateTime(2024, 8, 12, 00, 00, 0);
            newitem1.MealCategoryId = 1;
            newitem1.MealId = null;
            newitem1.UserId = 13;

            mealVoteGridModels.Add(newitem1);

            var result =_mealController.SaveMealVoting(mealVoteGridModels);

            Assert.NotNull(result);
        }
     }                          
}                                  
                                   