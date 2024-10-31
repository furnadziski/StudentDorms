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
    public class MyProfileGridModel
    {
   
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
        /// Блок
        /// </summary>
        public string Block { get; set; }

        /// <summary>
        /// Соба
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Пол на корсник
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Пол на корсник
        /// </summary>
        public string StudentDorm { get; set; }

        /// <summary>
        /// Дали е активен корисникот
        /// </summary>
        public bool IsActive { get; set; }


    }
}
