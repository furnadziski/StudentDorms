using Microsoft.Data.SqlClient;
using StudentDorms.AutoMapper;
using StudentDorms.Common;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models;
using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.XmlModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml2CSharp;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
   public class MealService : IMealService
    {

        private readonly IProcedureRepository<MealCategoryGridModel> _procedureRepositoryMealCategory;
        private readonly IProcedureRepository<MealGridModel> _procedureRepositoryMeal;
        private readonly IProcedureRepository<ScalarString> _storedProcedureScalar;
        private readonly IMealCategoryRepository _mealCategoryRepository;
        private readonly IMealRepository _mealRepository;

        public MealService(IProcedureRepository<MealCategoryGridModel> procedureRepositoryMealCategory, IMealCategoryRepository mealCategoryRepository, 
            IProcedureRepository<MealGridModel> procedureRepositoryMeal, IMealRepository mealRepository, IProcedureRepository<ScalarString> storedProcedureScalar)
        {
            _procedureRepositoryMealCategory = procedureRepositoryMealCategory;
            _mealCategoryRepository = mealCategoryRepository;
            _procedureRepositoryMeal = procedureRepositoryMeal;
            _mealRepository = mealRepository;
            _storedProcedureScalar = storedProcedureScalar;
        }
      


        public SearchResult<MealCategoryGridModel> GeMealCategoriesForGrid(MealCategorySearchModel mealCategorySearchModel)
        {

            if (mealCategorySearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(mealCategorySearchModel.SearchText) ? mealCategorySearchModel.SearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(mealCategorySearchModel.OrderColumn) ? mealCategorySearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", mealCategorySearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", mealCategorySearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", mealCategorySearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryMealCategory.ExecListResultQuery("[config].[FilterMealCategories]", parameters.ToArray());
            var result = new SearchResult<MealCategoryGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }
        public WeeklyMealsXmlModel FilterMealSchedule(FilterMealSearchModel filterMealSearchModel)
        {

            if (filterMealSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StartDateTime", SqlDbType.DateTime) { Value = filterMealSearchModel.StartDateTime });
            parameters.Add(new SqlParameter("@EndDateTime", SqlDbType.DateTime) { Value = filterMealSearchModel.EndDateTime });

            var storedProcedureResult = _storedProcedureScalar.ExecListResultQuery("[config].[FilterMealSchedule]", parameters.ToArray());
             WeeklyMealsXmlModel weeklyMeals = new WeeklyMealsXmlModel();
            if (storedProcedureResult.FirstOrDefault() == null)
            {
                return weeklyMeals;

            }
            weeklyMeals = XMLSerializer.Deserialize<WeeklyMealsXmlModel>(storedProcedureResult.FirstOrDefault().Value); 
            return weeklyMeals;
            
        }

        public WeeklyMealsVoting FilterMealVoting(FilterMealVotingSearchModel filterMealVotingSearchModel)
        {

            if (filterMealVotingSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserId", filterMealVotingSearchModel.UserId));
            var storedProcedureResult = _storedProcedureScalar.ExecListResultQuery("[meal].[FilterMealVoting]", parameters.ToArray());
            WeeklyMealsVoting weeklyMealsVoting = new WeeklyMealsVoting();
            if (storedProcedureResult.FirstOrDefault() == null)
            {
                return weeklyMealsVoting;

            }
            weeklyMealsVoting = XMLSerializer.Deserialize<WeeklyMealsVoting>(storedProcedureResult.FirstOrDefault().Value);
            return weeklyMealsVoting;

        }


        public SearchResult<MealGridModel> GetMealsForGrid(MealSearchModel mealSearchModel)
        {

            if (mealSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(mealSearchModel.SearchText) ? mealSearchModel.SearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@MealCategoryId", mealSearchModel.MealCategoryId.HasValue ? mealSearchModel.MealCategoryId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(mealSearchModel.OrderColumn) ? mealSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", mealSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", mealSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", mealSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryMeal.ExecListResultQuery("[config].[FilterMeals]", parameters.ToArray());
            var result = new SearchResult<MealGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }
        public void CreateMeal(MealCreateUpdateModel mealCreateUpdateModel)
        {
            if (mealCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }

            var meal = mealCreateUpdateModel.ToDomain<Meal, MealCreateUpdateModel>();

            _mealRepository.Create(meal);
        }

        public void UpdateMeal(MealCreateUpdateModel mealCreateUpdateModel)
        {
            if (mealCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да биде null ");
            }

            var meal = _mealRepository.GetById(mealCreateUpdateModel.Id);
            if (meal == null)
            {
                throw new StudentDormsException("Не постои запис за блок во база");
            }

            meal.MealCategoryId = mealCreateUpdateModel.MealCategoryId;
            meal.Name = mealCreateUpdateModel.Name;
            meal.Order = mealCreateUpdateModel.Order; 
            _mealRepository.Update(meal);
        }
        public void DeleteMealById(int id)
        {
            var deletedMeal = _mealRepository.GetById(id);

            if (deletedMeal == null)
            {
                throw new StudentDormsException("Оброкот со даденотo id не постои");
            }

            if (_mealRepository.HasAssociatedWeeklyMeals(id))
            {
                throw new StudentDormsException("За оброкот постои неделен оброк");
            }
            else _mealRepository.DeleteById(id);
        }
    }
}
