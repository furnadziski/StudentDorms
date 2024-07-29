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
    /// Класа во која се чуваат информации за студентскиот дом
    /// </summary>
    public class StudentDorm : BaseEntity<int>
    {
        /// <summary>
        /// Име на студентски дом
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на студентски дом
        /// </summary>
        public int Order { get; set; }
    }
}
