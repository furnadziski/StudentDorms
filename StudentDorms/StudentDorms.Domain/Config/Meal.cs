using StudentDorms.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
{
    /// <summary>
    /// Класа во која се чуваат информации за оброк
    /// </summary>
    public class Meal : BaseEntity<int>
    {
        /// <summary>
        /// Име на оброк
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Надворешен клуч до категорија на оброци
        /// </summary>
  
        public int MealCategoryId { get; set; }

        /// <summary>
        /// Категорија на оброк
        /// </summary>
        [ForeignKey("MealCategoryId")]
        public MealCategory MealCategory { get; set; }

        /// <summary>
        /// Реден број на оброк
        /// </summary>
        public int Order { get; set; }
    }
}
