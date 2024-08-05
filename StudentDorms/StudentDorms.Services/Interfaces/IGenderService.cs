using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{
    public interface IGenderService
    {
         /// <summary>
         /// Метод за листање на сите полови
         /// </summary>
         /// <returns>Листа на сите полови</returns>
        public List<DropdownViewModel<int>> GetGendersForDropdown();
    }
}
