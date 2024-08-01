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
    /// Класа во која се чуваат информации за улогите на корисникот
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Надворешен клуч до профилот на корисникот
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        ///  Профилот на корисникот
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Надворешен клуч до улогата на тој корисник
        /// </summary>
        [Key]
        public int RoleId { get; set; }

        /// <summary>
        /// Улогата на корисникот
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
