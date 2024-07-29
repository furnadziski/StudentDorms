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
    /// Класа во која се чуваат информации за годишно сместување по корисник
    /// </summary>
    public class AnnualAccommodationUser :BaseEntityWithTimestamp<int>
    {
        /// <summary>
        /// Надворешен клуч до годшно сместување
        /// </summary>
        public int AnnualAccommodationId { get; set; }

        /// <summary>
        /// Годишно сместување
        /// </summary>
        [ForeignKey("AnnualAccommodationId")]
        public virtual AnnualAccommodation AnnualAccommodation { get; set; }

        /// <summary>
        /// Надворешен клуч до профилот на корисникот
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///  Профилот на корисникот
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
