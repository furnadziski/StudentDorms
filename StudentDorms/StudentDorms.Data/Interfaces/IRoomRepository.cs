using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{     /// <summary>
      /// Репозитори за соби
      /// </summary>
    public interface IRoomRepository : IGenericRepository<Room>
    {
        /// <summary>
        /// Метод кој враќа дали собата е поврзан со некое годишно сместување (returns true if there is room associated)
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public bool HasAssociatedAnnualAccommodations(int roomid);
    }

}
