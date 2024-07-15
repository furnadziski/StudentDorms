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

namespace StudentDorms.Services.Interfaces
{
    /// <summary>
    /// Сервисен интерфејс за менаџирање на рестораните
    /// </summary>
    public interface IRestaurantService
    {

        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="restaurantSearchModel"></param>
        /// <returns>Листа од Грид модел за ресторанот</returns>
        SearchResult<RestaurantGridModel> GetRestaurantsForGrid(RestaurantSearchModel restaurantSearchModel);

        /// <summary>
        /// Метод за креирање на ресторан
        /// </summary>
        /// <param name="restaurantCreateUpdateModel"></param>
        /// <returns>креирање на модел за ресторан</returns>
        void CreateRestaurant(RestaurantCreateUpdateModel restaurantCreateUpdateModel);

        /// <summary>
        /// Метод за едитирање на ресторан
        /// </summary>
        /// <param name="restaurantCreateUpdateModel"></param>
        /// <returns>едитирање на модел за ресторан</returns>
        void UpdateRestaurant(RestaurantCreateUpdateModel restaurantCreateUpdateModel);

        /// <summary>
        /// Метод за бришење на ресторан
        /// </summary>
        /// <param name="id"></param>
        /// <returns>бришење на модел за рестораните</returns>
        void DeleteRestaurantById(int id);

        /// <summary>
        /// Метод за пребарување на ресторан по тип на ид
        /// </summary>
        /// <returns>Ресторн по ид</returns>
        RestaurantCreateUpdateModel GetRestaurantById(int restaurantId);

        /// <summary>
        /// Метод за листање на сите ресторани
        /// </summary>
        /// <returns>Листа на сите ресторани</returns>
        List<DropdownViewModel<int>> GetRestaurantsForDropdown();

    }
}
