using StudentDorms.Domain.Config;
using StudentDorms.Models.GridModels;
using Microsoft.EntityFrameworkCore;

namespace StudentDorms.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set;}
        public DbSet<Block> Blocks { get; set;}
        public DbSet<Gender> Genders { get; set;}
        public DbSet<Meal> Meals { get; set;}
        public DbSet<MealCategory> mealCategories { get; set;}
        public DbSet<Role> Roles { get; set;}
        public DbSet<Room> Rooms { get; set;}
        public DbSet<StudentDorm> StudentDorms { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<UserRole> UserRoles { get; set;}
        public DbSet<WeeklyMeal> WeeklyMeals { get; set;}
        public DbSet<AnnualAccommodation> AnnualAccommodations { get; set;}
        public DbSet<AnnualAccommodationUser> AnnualAccommodationUsers { get; set;}
        public DbSet<UserGridModel> UserGridModel { get; set;}





        
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
            modelBuilder.Entity<UserGridModel>().HasNoKey();


            modelBuilder.Entity<Block>().ToTable("Blocks","config");
            modelBuilder.Entity<Gender>().ToTable("Genders","config");
            modelBuilder.Entity<Meal>().ToTable("Meals","config");
            modelBuilder.Entity<MealCategory>().ToTable("MealCategories","config");
            modelBuilder.Entity<Role>().ToTable("Roles","config");
            modelBuilder.Entity<Room>().ToTable("Rooms","config");
            modelBuilder.Entity<StudentDorm>().ToTable("StudentDorms","config");
            modelBuilder.Entity<User>().ToTable("Users","config");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles","config");
            modelBuilder.Entity<WeeklyMeal>().ToTable("WeeklyMeals","meal");
            modelBuilder.Entity<AnnualAccommodation>().ToTable("AnnualAccommodations", "accommodations");
            modelBuilder.Entity<AnnualAccommodationUser>().ToTable("AnnualAccommodationUsers", "accommodations");


            #region lists
            modelBuilder.Entity<UserRole>().HasKey((x => new { x.UserId, x.RoleId }));
            modelBuilder.Entity<UserRole>()
                        .HasOne<User>(x => x.User)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(sd => sd.UserId);

            modelBuilder.Entity<UserRole>()
                        .HasOne<Role>(r => r.Role)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<AnnualAccommodationUser>().HasKey((x=> x.Id));
            modelBuilder.Entity<AnnualAccommodationUser>()
                        .HasOne<AnnualAccommodation>(x => x.AnnualAccommodation)
                        .WithMany(x => x.AnnualAccommodationUsers)
                        .HasForeignKey(sd => sd.AnnualAccommodationId);

            modelBuilder.Entity<AnnualAccommodationUser>()
                        .HasOne<User>(x => x.User)
                        .WithMany(x => x.AnnualAccommodationUsers)
                        .HasForeignKey(sd => sd.UserId);
            #endregion
        }
    }
}
