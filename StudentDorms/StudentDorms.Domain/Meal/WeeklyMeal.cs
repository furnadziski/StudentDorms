using StudentDorms.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
{
    /// <summary>
    /// Класа во која се чуваат информации за неделен оброк
    /// </summary>
    public class WeeklyMeal : BaseEntityWithTimestamp<int>
    {
        /// <summary>
        /// Надворешен клуч до профилот на корисникот
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Профилот на корисникот
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Надворешен клуч до оброк
        /// </summary>
        public int? MealId { get; set; }

        /// <summary>
        /// Оброк
        /// </summary>
        [ForeignKey("MealId")]
        public virtual Meal Meal { get; set; }

        public DateTime Date { get; set; }

    }
}
