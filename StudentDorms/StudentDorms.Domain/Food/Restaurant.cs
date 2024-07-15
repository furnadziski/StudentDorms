using StudentDorms.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
{
    /// <summary>
    /// Класа во која се чуваат информации за рестораните
    /// </summary>
    public class Restaurant : BaseEntityWithTimestamp<int>
    {
        /// <summary>
        /// Редоследот на рестораните
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Бројот на попустот на секој ресторан
        /// </summary>
        public int  Participation { get; set; }

        /// <summary>
        /// Име на ресторанот
        /// </summary>
        public string Name { get; set; }
    }
}
