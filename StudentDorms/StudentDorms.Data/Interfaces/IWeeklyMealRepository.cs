using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using StudentDorms.Models.GridModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{
    public interface IWeeklyMealRepository : IGenericRepository<WeeklyMeal>
    {
        public WeeklyMeal GetVotedWeeklyMeals(int userId, int mealCategoryid, DateTime date);
       
    }

         
}
