using StudentDorms.Models.Base;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{
    /// <summary>
    /// Сервисен интерфејс за менаџирање на категории за оброци
    /// </summary>
    public interface IMealService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="mealCategorySearchModel"></param>
        /// <returns>Листа од Грид модел за категорија на оброци</returns>
        public SearchResult<MealCategoryGridModel> GeMealCategoriesForGrid(MealCategorySearchModel mealCategorySearchModel);

        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="mealSearchModel"></param>
        /// <returns>Листа од Грид модел за оброци</returns>
        public SearchResult<MealGridModel> GetMealsForGrid(MealSearchModel mealSearchModel);
    }
}
