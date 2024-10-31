using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.ViewModels
{
    public class UserViewModel
    {
        /// <summary>
        /// Ид на корсник
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име  на корисник
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// презиме на корисник
        /// </summary>
        public string LastName { get; set; }

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
        public List<DropdownViewModel<int>> Roles { get; set; }

        /// <summary>
        /// Пол на корсник
        /// </summary>
        public DropdownViewModel<int> Gender { get; set; }

        /// <summary>
        /// Дали е активен корисникот
        /// </summary>
        public bool IsActive { get; set; }
    }
}
