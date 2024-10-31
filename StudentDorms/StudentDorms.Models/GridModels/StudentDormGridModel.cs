using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{  /// <summary>
   /// Модел во кој се чуваат инфромации за студентскиот дом
   /// </summary>
    public class StudentDormGridModel
        {

        /// <summary>
        /// Ид на студентскиот дом
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на студентскиот дом
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на студентскиот дом
        /// </summary>
        public int Order { get; set; }

    }
}
