using StudentDorms.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
{
    /// <summary>
    /// Класа во која се чуваат информации за улогите
    /// </summary>
    public class Role : BaseEntity<int>
    {
        /// <summary>
        /// Име на улогата
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Листа на улоги за корисник
        /// </summary>
        public IList<UserRole> UserRoles { get; set; }
    }
}
