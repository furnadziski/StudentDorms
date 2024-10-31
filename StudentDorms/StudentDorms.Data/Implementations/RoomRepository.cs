using Microsoft.EntityFrameworkCore;
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

        public Room GetRoomForUpdateById(int id)
        {
            return DbSet.Include(x => x.Block).ThenInclude(x => x.StudentDorm).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Room> GetRoomsForDropdownByBlockId(int id)
        {
            return DbSet
                .Include(x => x.Block).Where(x => x.BlockId == id).ToList();


        }
    }
}
