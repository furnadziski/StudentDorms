using StudentDorms.Data.Context;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;

namespace StudentDorms.Data.Implementations
{
    public class AnnualAccommodationUserRepository : GenericRepository<AnnualAccommodationUser>, IAnnualAccommodationUserRepository
    {
        public AnnualAccommodationUserRepository(DatabaseContext context) : base(context)
        {


        }
    }

}