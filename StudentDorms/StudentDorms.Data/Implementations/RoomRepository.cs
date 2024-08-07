using StudentDorms.Data.Context;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(DatabaseContext context) : base(context)
        {
        }
        public bool HasAssociatedAnnualAccommodations(int roomid)
        {
            return Context.AnnualAccommodations
                   .Any(b => b.RoomId == roomid);
        }
    }
}
