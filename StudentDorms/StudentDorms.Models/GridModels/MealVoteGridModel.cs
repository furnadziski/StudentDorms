using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.GridModels
{
    public class MealVoteGridModel
    {

        public int Id { get; set; }
        public int? MealId { get; set; }
        public int MealCategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
