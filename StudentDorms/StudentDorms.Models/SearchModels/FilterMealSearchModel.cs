using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{    /// <summary>
     /// Модел во кој се чуваат инфромации за пребарување на обороци
     /// </summary>
    public class FilterMealSearchModel
    {
        /// <summary>
        /// Почеток на недела
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Крај на недела
        /// </summary>
        public DateTime EndDateTime { get; set; }
    }
}
