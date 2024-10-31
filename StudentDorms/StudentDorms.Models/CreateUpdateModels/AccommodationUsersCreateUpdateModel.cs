using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{ /// <summary>
  /// Модел со кој се прикажуаат податоците за годишно сместување по корисник
  /// </summary>
    public class AccommodationUsersCreateUpdateModel
    {
        /// <summary>
        /// Ид на годишно сместување по корисник
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ид  на годишно сместување 
        public int AnnualAccommodationId { get; set; }

        /// <summary>
        /// Ид на корисник на годишно сместување по корисник
        /// </summary>
        public List<DropdownViewModel<int>> Users { get; set; }
    }
}
