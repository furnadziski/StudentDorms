using StudentDorms.AutoMapper;
using StudentDorms.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CoMS.NUnitTesting.Configuration
{
    public static class ConfigureDependencies
    {
        public static DatabaseContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("data source=dri-dev;initial catalog=COMS;persist security info=True;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;")
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
