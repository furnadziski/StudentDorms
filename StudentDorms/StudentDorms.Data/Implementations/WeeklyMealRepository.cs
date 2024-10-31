using Microsoft.EntityFrameworkCore;
using StudentDorms.Data.Context;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.GridModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
   public  class WeeklyMealRepository : GenericRepository<WeeklyMeal>, IWeeklyMealRepository
    {
        public WeeklyMealRepository(DatabaseContext context) : base(context)
        {
        }

     
        public WeeklyMeal GetVotedWeeklyMeals(int userId,int mealCategoryid,DateTime date)
        {
            return DbSet
                .Include(x => x.Meal)
                 .Where(x => x.UserId == userId && x.Date.Date == date.Date &&
                 x.Meal.MealCategoryId == mealCategoryid).FirstOrDefault();
        }
    }
}
