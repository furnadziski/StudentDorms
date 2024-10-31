using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.ViewModels
{
    /// <summary>
    /// Модел во кој се чуваат податоци потребни за листање на блокови
    /// </summary>
     public class BlockViewModel
    {
        /// <summary>
        /// Ид на блок
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на блок
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на блок
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///  Студентски дом во кој е блокот
        /// </summary>
        public DropdownViewModel<int> StudentDorm { get; set; }

    }
}
