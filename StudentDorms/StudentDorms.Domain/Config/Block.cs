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
    /// Класа во која се чуваат информации за блокот
    /// </summary>
    public class Block : BaseEntity<int>
    {
        /// <summary>
        /// Надворешен клуч до студентскиот дом
        /// </summary>
        public int StudentDormId { get; set; }

    
        /// <summary>
        /// Студентскиот дом
        /// </summary>
        [ForeignKey("StudentDormId")]
        public virtual StudentDorm StudentDorm { get; set; }

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

