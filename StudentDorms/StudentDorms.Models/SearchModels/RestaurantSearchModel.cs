using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{

    /// <summary>
    /// Модел во кој се чуваат моделите за филтрирање на рестораните
    /// </summary>
    public class RestaurantSearchModel : BaseSearchModel
    {
        /// <summary>
        /// Текст по кој се пребарува еден ресторан 
        /// </summary>
        public string SearchText { get; set; }
    }
}
