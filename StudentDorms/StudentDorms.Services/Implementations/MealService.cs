using Microsoft.Data.SqlClient;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.Base;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
   public class MealService : IMealService
    {

        private readonly IProcedureRepository<MealCategoryGridModel> _procedureRepositoryMealCategory;
        private readonly IProcedureRepository<MealGridModel> _procedureRepositoryMeal;
        private readonly IMealCategoryRepository _mealCategoryRepository;
        private readonly IMealRepository _mealRepository;

        public MealService(IProcedureRepository<MealCategoryGridModel> procedureRepositoryMealCategory, IMealCategoryRepository mealCategoryRepository, IProcedureRepository<MealGridModel> procedureRepositoryMeal, IMealRepository mealRepository)
        {
            _procedureRepositoryMealCategory = procedureRepositoryMealCategory;
            _mealCategoryRepository = mealCategoryRepository;
            _procedureRepositoryMeal = procedureRepositoryMeal;
            _mealRepository = mealRepository;
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
    }
}
