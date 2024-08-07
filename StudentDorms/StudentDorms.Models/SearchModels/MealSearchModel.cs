using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{   /// <summary>
    /// Модел во кој се чуваат инфромации за оброк
    /// </summary>
  public  class MealSearchModel:BaseSearchModel
    {
        /// <summary>
        /// Текст по кој се пребарува еден оброк
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Ид на категорија за оброци по која се пребарува еден оброк
        /// </summary>
        public int? MealCategoryId { get; set; }
    }
}
