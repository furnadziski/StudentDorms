using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{
    public class WeeklyMealCreateUpdateModel
    {

        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ид на  оброк
        /// </summary>
        public int? MealId { get; set; }

        /// <summary>
        /// Име на неделен оброк
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата на неделен оброк
        /// </summary>
        public DateTime Date { get; set; }

    

        /// <summary>
        ///  Ид на корисник за неделен оброк
        /// </summary>
        public int UserId { get; set; }
    }
}

