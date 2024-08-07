using StudentDorms.Data.Context;
using StudentDorms.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
    public class MealRepository : GenericRepository<MealRepository>, IMealRepository
    {
        public MealRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
