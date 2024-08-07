using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{   /// <summary>
    /// Модел во кој се чуваат инфромации за блокот
    /// </summary>
   public class BlockSearchModel :BaseSearchModel
    {
        /// <summary>
        /// Текст по кој се пребарува еден блок
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Ид на студентски дом по кој се пребарува еден корисник
        /// </summary>
        public int? StudentDormId { get; set; }
    }
}
