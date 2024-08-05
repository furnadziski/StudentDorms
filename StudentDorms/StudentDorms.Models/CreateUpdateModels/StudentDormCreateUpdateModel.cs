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

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
    }
}
