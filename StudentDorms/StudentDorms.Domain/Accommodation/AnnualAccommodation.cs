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
    /// Класа во која се чуваат информации за годишно сместување
    /// </summary>
    public class AnnualAccommodation : BaseEntity<int>
    {
        public int Year { get; set; }

        /// <summary>
        /// Надворешен клуч до соба
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Соба
        /// </summary>
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        /// <summary>
        /// Листа на годишни сместувања
        /// </summary>
        public IList<AnnualAccommodationUser> AnnualAccommodationUsers { get; set; }
    }
}
