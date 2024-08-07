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
    public class MealCategoryRepository : GenericRepository<MealCategoryRepository>, IMealCategoryRepository
    {
        public MealCategoryRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
