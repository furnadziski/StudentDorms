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
    /// Класа во која се чуваат информации за корисниците
    /// </summary>
    public class User : BaseEntityWithTimestamp<int>
    {
        /// <summary>
        /// Име на корисникот
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Презиме на корисникот
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Корисничко име  на корисникот
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Е-пошта на корисникот
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Надворешен клуч до полот на овој узер
        /// </summary>

        public int GenderId{ get; set; }

        /// <summary>
        /// Полот на узерот
        /// </summary>
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Дали корисничкиот профил е активен
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Листа на улоги за корисник
        /// </summary>
       public IList<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Листа на годишно сместување за корисник
        /// </summary>
        public IList<AnnualAccommodationUser> AnnualAccommodationUsers { get; set; }






    }
}
