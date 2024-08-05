using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{
    public interface IRoleService

    {    /// <summary>
         /// Метод за листање на сите улоги
         /// </summary>
         /// <returns>Листа на сите улоги</returns>
        public List<DropdownViewModel<int>> GetRolesForDropdown();
    }
}
