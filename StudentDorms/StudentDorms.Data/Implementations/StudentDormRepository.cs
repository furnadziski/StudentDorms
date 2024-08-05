﻿using Microsoft.EntityFrameworkCore;
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
    public class StudentDormRepository : GenericRepository<StudentDorm>, IStudentDormRepository
    {
        public StudentDormRepository(DatabaseContext context) : base(context)
        {
        
        }
       public bool HasAssociatedBlocks(int studentDormId)
          {
             return Context.Blocks
                    .Any(b => b.StudentDormId == studentDormId);
           }
    }
}
