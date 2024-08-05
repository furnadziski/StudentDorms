using StudentDorms.AutoMapper;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Implementations
{
    public class GenderService :IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public List<DropdownViewModel<int>> GetGendersForDropdown()
        {
            var genders = _genderRepository.GetAll();

            if (genders == null)
            {
                throw new StudentDormsException("Не постои запис за половите ");

            }
            var result = genders.Select(x => x.ToModel<DropdownViewModel<int>, Gender>()).ToList();
            return result;

        }
    }
}
