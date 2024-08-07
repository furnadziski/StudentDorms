using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{    /// <summary>
     /// Модел со кој се прикажуаат податоците за блоковите
     /// </summary>
    public class BlockCreateUpdateModel
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
        public int StudentDormId { get; set; }
    }
}
