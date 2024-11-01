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
   
    public class BlockRepository :GenericRepository<Block> , IBlockRepository
    {
        public BlockRepository(DatabaseContext context) : base(context)
        { 
        }
        public bool HasAssociatedRooms(int blockId)
        {
            return Context.Rooms
                   .Any(b => b.BlockId == blockId);
        }

        public Block GetBlockForUpdateById(int id)
        {
            return DbSet.Include(x => x.StudentDorm).Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<Block> GetBlockByStudentDormId(int id)
        {
            return DbSet
                .Include(x=>x.StudentDorm).Where(x => x.StudentDormId == id).ToList();
                   
              
        }
    }
}
