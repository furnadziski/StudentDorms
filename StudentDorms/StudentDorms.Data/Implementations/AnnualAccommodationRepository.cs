using Microsoft.EntityFrameworkCore;
using StudentDorms.Data.Context;
using StudentDorms.Data.Extensions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
    public class AnnualAccommodationRepository : GenericRepository<AnnualAccommodation>, IAnnualAccommodationRepository
    {
        public AnnualAccommodationRepository(DatabaseContext context) : base(context)
        {


        }
        public AnnualAccommodation GetByIdWithStudents(int id)
        {
            return DbSet
                .Include(x => x.AnnualAccommodationUsers).ThenInclude(x => x.User).Include(x=>x.Room)                
                                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
