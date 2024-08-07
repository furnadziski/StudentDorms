using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{    /// <summary>
     /// Модел во кој се чуваат инфромации за оброкот
     /// </summary>
    public class MealGridModel
    {
        /// <summary>
        /// Ид на оброк
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на оброк
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Име на категорија за оброк
        /// </summary>
        public string MealCategoryName { get; set; }

        /// <summary>
        /// Реден број на оброк
        /// </summary>
        public int Order { get; set; }
    }

}
