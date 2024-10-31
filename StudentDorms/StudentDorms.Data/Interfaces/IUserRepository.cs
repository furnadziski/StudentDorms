using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using StudentDorms.Models.Enums;
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

        public IEnumerable<User> GetUsersByRole(RolesEnum role);
        public IEnumerable<User> GetUsersByRoleAndBlock(RolesEnum role, int blockId, int year);
    }

}
