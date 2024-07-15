using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{

    /// <summary>
    /// Модел во кој се чуваат инфромации за категоријата
    /// </summary>
    public class RestaurantGridModel
    {
        /// <summary>
        /// Ид на ресторанот
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Редоследот на рестораните
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Бројот на попустот во секој од рестораните
        /// </summary>
        public int Participation { get; set; }

        /// <summary>
        /// Име на ресторанот
        /// </summary>
        public string Name { get; set; }

    }
}
