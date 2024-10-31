using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.ViewModels
{
       public class AccommodationViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Име на соба
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Капацитет
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Зафатеност
        /// </summary>
        public int Occupancy { get; set; }

        /// <summary>
        /// Студенти
        /// </summary>
        public List<DropdownViewModel<int>> Students { get; set; }
    }
}
