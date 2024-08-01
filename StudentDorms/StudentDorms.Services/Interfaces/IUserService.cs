using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{    /// <summary>
     /// Сервисен интерфејс за менаџирање на корисници
     /// </summary>
     public interface IUserService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="userSearchModel"></param>
        /// <returns>Листа од Грид модел за корисникот</returns>
        SearchResult<UserGridModel> GetUsersForGrid(UserSearchModel userSearchModel);

        /// <summary>
        /// Метод за креирање на корисник
        /// </summary>
        /// <param name="userCreateUpdateModel"></param>
        /// <returns>креирање на модел за корисник</returns>
        void CreateUser(UserCreateUpdateModel userCreateUpdateModel);

        /// <summary>
        /// Метод за едитирање на корисник
        /// </summary>
        /// <param name="userCreateUpdateModel"></param>
        /// <returns>едитирање на модел за корисник</returns>
        public void UpdateUser(UserCreateUpdateModel userCreateUpdateModel);

    }
}
