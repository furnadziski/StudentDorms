using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.ViewModels
{
    /// <summary>
    /// Модел во кој се чуваат податоци потребни за листање на оброци
    /// </summary>
    public class MealViewModel
    {
        /// <summary>
        /// Ид на оброк
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на оброк
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реден број на оброк
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///  Категорија на оброк
        /// </summary>
        public DropdownViewModel<int> MealCategory { get; set; }

    }
}
