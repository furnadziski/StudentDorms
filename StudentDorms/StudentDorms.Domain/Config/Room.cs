using StudentDorms.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Domain.Config
{
    /// <summary>
    /// Класа во која се чуваат информации за Собата
    /// </summary>
    public class Room : BaseEntity<int>
    {
     
        /// <summary>
        /// Број на соба
        /// </summary>
        public string RoomNo { get; set; }

        /// <summary>
        /// Надворешен клуч до блокот
        /// </summary>
        public int BlockId { get; set; }

        /// <summary>
        /// Блок
        /// </summary>
        [ForeignKey("BlockId")]
        public virtual Block Block { get; set; }

        /// <summary>
        /// Капацитет на собата
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Реден број на собата
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Дали собата е во функција
        /// </summary>
        public bool IsActive { get; set; }
    }
}
