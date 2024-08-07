using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{
    /// <summary>
    /// Модел во кој се чуваат инфромации за категории на оброци
    /// </summary>
    public class MealCategorySearchModel : BaseSearchModel 
    {
        /// <summary>
        /// Текст по кој се пребарува едена категорија на оброци
        /// </summary>
        public string SearchText { get; set; }
    }
}
