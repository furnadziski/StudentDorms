using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{    /// <summary>
     /// Модел со кој се прикажуаат податоците за корисниците
     /// </summary>
    public class UserCreateUpdateModel
    {
        /// <summary>
        /// Ид на корисник кој се едитира
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на корисник кој се едитира/креира
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///  Презиме на корисник кој се едитира/креира
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  Корисничко име на корисник кој се едитира/креира
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///  Емаил на корисник кој се едитира/креира
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Листа со улоги на корисник кој се едитира/креира
        /// </summary>
        public List<DropdownViewModel<int>> Roles { get; set; }

        /// <summary>
        /// Пол на корисник кој се едитира/креира
        /// </summary>
        public int GenderId { get; set; }
        /// <summary>
        ///  Дали е активен на корисник кој се едитира/креира
        /// </summary>
        public bool IsActive { get; set; }


    }
}
