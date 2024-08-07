using StudentDorms.Data.Extensions;
using StudentDorms.Data.Implementations;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{
    public interface IMealRepository : IGenericRepository<MealRepository>
    {
    }
}

