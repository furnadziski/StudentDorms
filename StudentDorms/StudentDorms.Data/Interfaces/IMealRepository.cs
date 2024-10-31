using StudentDorms.Data.Extensions;
using StudentDorms.Data.Implementations;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{     /// <summary>
      /// Репозитори за обоци
      /// </summary>
    public interface IMealRepository : IGenericRepository<Meal>
    {
        /// <summary>
        /// Метод кој враќа дали оброкот е поврзан со некој неделен оброк (returns true if there is weeklymeal associated)
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public bool HasAssociatedWeeklyMeals(int mealid);

        public Meal GetMealForUpdateById(int id);
        public IEnumerable<Meal> GetMealsByCategoryId(int id);

    }
}

