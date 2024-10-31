using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{   /// <summary>
    /// Модел со кој се прикажуаат податоците за годишно сместување
    /// </summary>
    public class AccommodationCreateUpdateModel
    {
        /// <summary>
        /// Ид на годишно сместување
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Година на годишно сместување
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Ид на соба на годишно сместување
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Корисници за годишно сместување
        /// </summary>
        public List<DropdownViewModel<int>> Users { get; set; }
    }
}
