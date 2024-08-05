using StudentDorms.AutoMapper;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
    public class RoleService :IRoleService
    {
       
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<DropdownViewModel<int>> GetRolesForDropdown()
        {
            var roles = _roleRepository.GetAll();
            if (roles == null)
            {
                throw new StudentDormsException("Не постои запис за улогите");

            }
            var result = roles.Select(x => x.ToModel<DropdownViewModel<int>, Role>()).ToList();
            return result;
            
        }

    }
}
