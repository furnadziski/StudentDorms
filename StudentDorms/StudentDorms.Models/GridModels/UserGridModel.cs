using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{
    /// <summary>
    /// Модел во кој се чуваат инфромации за корисникот
    /// </summary>
    public class UserGridModel
    {  
        /// <summary>
        /// Ид на корсник
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име и презиме на корисник
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Корисничко име на корисник
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Е-пошта на корсник
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Улоги на на корсник
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Пол на корсник
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Дали е активен корисникот
        /// </summary>
        public bool IsActive { get; set; }
     

    }
}
