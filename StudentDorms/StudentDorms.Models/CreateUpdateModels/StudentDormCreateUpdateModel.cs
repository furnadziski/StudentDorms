using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{   /// <summary>
    /// Модел со кој се прикажуаат податоците за студентските домови
    /// </summary>
    public class StudentDormCreateUpdateModel
    {
        /// <summary>
        /// Ид на студентски кој се едитира
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Реден број на студентски кој се едитира/креира
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Име на студентски кој се едитира/креира
        /// </summary>
        public string Name { get; set; }
    }
}
