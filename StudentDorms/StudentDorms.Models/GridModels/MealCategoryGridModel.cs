using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{
    /// <summary>
    /// Модел во кој се чуваат инфромации за категорија на оброци
    /// </summary>
    public class MealCategoryGridModel
    {
        /// <summary>
        /// Име на категорија
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на категорија
        /// </summary>
        public int Order { get; set; }
    }
}
