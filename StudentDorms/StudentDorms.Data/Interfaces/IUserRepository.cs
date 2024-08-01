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
    /// Репозитори за корисници 
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Метод кој враќа корисник со улоги
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserWithRolesById(int id);
    }
}