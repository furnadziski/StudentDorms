using StudentDorms.Domain.Config;
using StudentDorms.Models.GridModels;
using Microsoft.EntityFrameworkCore;

namespace StudentDorms.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set;}
        
        #region Procedure models

        public DbSet<RestaurantGridModel> RestaurantGridModels { get; set; }
       
        #endregion

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants", "dbo");

            modelBuilder.Entity<RestaurantGridModel>().HasNoKey();


            #region Survey modelBuilder

            #endregion

            #region lists

            #endregion
        }
    }
}
