﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentDorms.Data.Interfaces;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Context;
using StudentDorms.Services.Interfaces;
using StudentDorms.Services.Implementations;
using static StudentDorms.Data.Interfaces.IProcedureRepository;
using StudentDorms.Models.GridModels;
using StudentDorms.Services;

namespace StudentDorms.Configuration
{
    public static class DependencyInjectionConfigurations
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISharedService, SharedService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStudentDormService,StudentDormService>();
            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IAnnualAccommodationService, AnnualAccommodationService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IRoomService, RoomService>();

        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStudentDormRepository, StudentDormRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IAnnualAccommodationRepository, AnnualAccommodationRepository>();
            services.AddScoped<IMealCategoryRepository, MealCategoryRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWeeklyMealRepository, WeeklyMealRepository>();
            services.AddScoped<IAnnualAccommodationUserRepository, AnnualAccommodationUserRepository>();
           
            services.AddScoped(typeof(IProcedureRepository<>), typeof(ProcedureRepository<>));
        }

        public static void AddServiceClients(this IServiceCollection services)
        {
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration["Database:ConnectionString"];
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(databaseConfig
                ), ServiceLifetime.Scoped);
        }
    }
}
