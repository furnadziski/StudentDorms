using StudentDorms.Data.Context;
using StudentDorms.Data.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDorms.Data.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<T> DbSet;

        protected GenericRepository(DatabaseContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
            try
            {
                Context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();

        }

        public void DeleteById(object id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
            }           
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(object id)
        {
            
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();         
        }
    }
}

