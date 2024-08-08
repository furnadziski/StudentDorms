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
    public class AccommodationRepository : GenericRepository<AnnualAccommodation>, IAccommodationRepository
    {
        public AccommodationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
