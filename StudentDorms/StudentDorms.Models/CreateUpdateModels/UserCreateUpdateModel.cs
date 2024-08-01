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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<DropdownViewModel<int>> Roles { get; set; }
        public int GenderId { get; set; }
        public bool IsActive { get; set; }


    }
}
