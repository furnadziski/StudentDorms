using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml2CSharp;

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

        /// <summary>
        /// Метод за креирање на оброк
        /// </summary>
        /// <param name="mealCreateUpdateModel"></param>
        /// <returns>креирање на модел за оброк</returns>
        public void CreateMeal(MealCreateUpdateModel mealCreateUpdateModel);

        /// <summary>
        /// Метод за едитирање на оброк
        /// </summary>
        /// <param name="mealCreateUpdateModel"></param>
        /// <returns>едитирање на модел за оброк</returns>
        public void UpdateMeal(MealCreateUpdateModel mealCreateUpdateModel);

        /// <summary>
        /// Метод за бришење на оброк
        /// </summary>
        /// <param name="id"></param>
        /// <returns>едитирање на модел за оброк</returns>
        public void DeleteMealById(int id);

        /// <summary>
        /// Метод зa прикажување на оброци
        /// </summary>
        /// <param name="filterMealSearchModel"></param>
        /// <returns>прикажувањена модел за оброк</returns>
        public WeeklyMealsXmlModel FilterMealSchedule(FilterMealSearchModel filterMealSearchModel);

        /// <summary>
        /// Метод зa прикажување на гласање за оборци
        /// </summary>
        /// <param name="filterMealVotingSearchModel"></param>
        /// <returns>прикажувањена модел за гласање за оборци<</returns>
        public WeeklyMealsVoting FilterMealVoting(FilterMealVotingSearchModel filterMealVotingSearchModel);


        /// <summary>
        /// Метод зa прикажување на гласање за оборци
        /// </summary>
        /// <param name="mealVoteGridModels"></param>
        /// <returns>прикажувањена модел за изгласани оборци<</returns>
        public void SaveMealVote(List<MealVoteGridModel> mealVoteGridModels);

        /// <summary>
        /// Метод зa прикажување на категории на оборци
        /// </summary>
        /// <returns>прикажување на категории на оборци<</returns>
        public List<DropdownViewModel<int>> GetMealCategoriesForDropdown();
        /// <summary>
        /// Метод зa прикажување  на оборци
        /// </summary>
        /// <returns>прикажување на  оборци<</returns>
        public List<DropdownViewModel<int>> GetMealsForDropdown(int id);

        /// <summary>
        /// Метод зa прикажување на оборк
        /// </summary>
        /// <param name="mealid"></param>
        /// <returns>прикажување на оборк<</returns>
        public MealViewModel GetMealById(int mealid);
    }
}
