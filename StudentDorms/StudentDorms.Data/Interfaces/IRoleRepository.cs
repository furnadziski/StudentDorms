﻿using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{
    /// <summary>
    /// Репозитори за улоги
    /// </summary>
   public interface IRoleRepository : IGenericRepository<Role>
    {

    }
}
