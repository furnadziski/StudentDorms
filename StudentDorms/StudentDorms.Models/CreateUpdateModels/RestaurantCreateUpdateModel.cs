using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{
    /// <summary>
    /// Модел со кој се прикажуаат податоците за рестораните
    /// </summary>
    public class RestaurantCreateUpdateModel
    {
        /// <summary>
        /// Ид на ресторан кој се едитира
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Редоследот на ресторанот кој што се едитира
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Број на попуст во секој ресторан 
        /// </summary>
        public int Participation { get; set; }

        /// <summary>
        /// Име  на ресторанот
        /// </summary>
        public string Name { get; set; }
    }
}
