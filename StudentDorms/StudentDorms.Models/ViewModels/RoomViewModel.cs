using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.ViewModels
{
   public class RoomViewModel
    {
        /// <summary>
        /// Ид на соба
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Капацитет на соба
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Реден број на соба
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///  Студентски дом во кој е собата
        /// </summary>
        public DropdownViewModel<int> StudentDorm { get; set; }

        /// <summary>
        ///  Студентски дом во кој е собата
        /// </summary>
        public DropdownViewModel<int> Block { get; set; }

        /// <summary>
        /// Име на соба
        /// </summary>
        public string RoomNo { get; set; }


    }
}
