using StudentDorms.AutoMapper;
using StudentDorms.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace StudentDorms.NUnitTesting.Configuration
{
    public static class ConfigureDependencies
    {
        public static DatabaseContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=StudentDorms;persist security info=True;Integrated Security=True;MultipleActiveResultSets=True;")
                .Options;
            var dbContext = new DatabaseContext(options);
            return dbContext;
        }

        public static void InitializeConfigurations()
        {
            AutoMapperConfiguration.Initialize();
        }

    }
}
