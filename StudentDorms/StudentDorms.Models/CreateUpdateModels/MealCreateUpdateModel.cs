using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{    /// <summary>
     /// Модел со кој се прикажуаат податоците за оброци
     /// </summary>
    public class MealCreateUpdateModel
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
        public int MealCategoryId { get; set; }

        /// <summary>
        /// Реден број на оброк
        /// </summary>
        public int Order { get; set; }

    }
}
