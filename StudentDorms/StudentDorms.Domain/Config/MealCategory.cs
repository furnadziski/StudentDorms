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
    /// Класа во која се чуваат информации за категорија на оброк
    /// </summary>
    public class MealCategory : BaseEntity<int>
    {
        /// <summary>
        /// Име на категоријата
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Реден број на категоријата
        /// </summary>
        public int Order { get; set; }
    
    }
}
