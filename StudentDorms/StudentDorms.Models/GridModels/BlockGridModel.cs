using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{   /// <summary>
    /// Модел во кој се чуваат инфромации за блокот
    /// </summary>
    public class BlockGridModel
    {
        /// <summary>
        /// Ид на блок
        /// </summary>
        public int Id { get; set; }
    
        /// <summary>
        /// Име на студентски дом
        /// </summary>
        public string StudentDorm { get; set; }

        /// <summary>
        /// Име на блок
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на блок
        /// </summary>
        public int Order { get; set; }

    }
}
