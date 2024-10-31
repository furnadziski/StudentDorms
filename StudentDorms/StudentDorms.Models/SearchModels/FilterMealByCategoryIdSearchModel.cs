using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{
    public class FilterMealByCategoryIdSearchModel : BaseSearchModel
    {
        /// <summary>
        /// Тип на оброк
        /// </summary>
        public int CategoryId { get; set; }
    }
}
