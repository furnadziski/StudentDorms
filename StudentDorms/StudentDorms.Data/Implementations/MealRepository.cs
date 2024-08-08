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
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {
        public MealRepository(DatabaseContext context) : base(context)
        {

        }
        public bool HasAssociatedWeeklyMeals(int mealid)
        {
            return Context.WeeklyMeals
                   .Any(b => b.MealId == mealid);
        }
    }
}
