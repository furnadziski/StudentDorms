using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.CreateUpdateModels
{
   public class RoomCreateUpdateModel
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
        /// Име на соба
        /// </summary>
        public string RoomNo { get; set; }

        /// <summary>
        /// Реден број на соба
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///  Блок во кој е собата
        /// </summary>
        public int BlockId { get; set; }

        /// <summary>
        /// Дали собата е активна
        /// </summary>
        public bool IsActive { get; set; }
    }
}
