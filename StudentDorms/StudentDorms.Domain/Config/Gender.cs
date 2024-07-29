using StudentDorms.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
 {   /// <summary>
     /// Класа во која се чуваат информации за половите
     /// </summary>
    public class Gender : BaseEntity<int>
    {
        /// <summary>
        /// Име на полот
        /// </summary>
        public string Name { get; set; }

    }
}
