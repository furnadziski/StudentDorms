using Microsoft.EntityFrameworkCore;
using StudentDorms.Data.Context;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        public User GetUserWithRolesById(int id)
        {
            return DbSet
                .Include(x => x.Gender)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
        public IEnumerable<User> GetUsersByRole(RolesEnum role)
        {
            return DbSet
                .Include(x => x.Gender)
                    .Include(x => x.UserRoles)
                        .ThenInclude(x => x.Role)
                .Where(x => x.UserRoles.Any(r => r.RoleId == (int)role))
                .ToList();
        }

        public IEnumerable<User> GetUsersByRoleAndBlock(RolesEnum role, int blockId,int year)
        {
            return DbSet
                .Include(x => x.AnnualAccommodationUsers)
                    .ThenInclude(x => x.AnnualAccommodation)
                        .ThenInclude(x => x.Room)
                            .ThenInclude(x => x.Block)
                .Where(x => x.UserRoles.Any(r => r.RoleId == (int)role) &&
                            x.AnnualAccommodationUsers.Any(a => a.AnnualAccommodation.Room.Block.Id == blockId)
                             &&
                            x.AnnualAccommodationUsers.Any(b =>b.AnnualAccommodation.Year == year))                               
                .ToList();
        }
    }
  }
