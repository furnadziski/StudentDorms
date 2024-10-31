using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{
    /// <summary>
    /// Модел во кој се чуваат инфромации за собата
    /// </summary>
    public class RoomGridModel
    {
        /// <summary>
        /// Ид на соба
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Капацитет на соба
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Реден број на соба
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Име на студентски дом
        /// </summary>
        public string StudentDorm { get; set; }

        /// <summary>
        /// Име на соба
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Име на блок
        /// </summary>
        public string BlockName { get; set; }

  
    }
}
