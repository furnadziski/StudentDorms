using StudentDorms.AutoMapper;
using StudentDorms.Configuration;
using StudentDorms.Middlewares;
using StudentDorms.Settings;
using StudentDorms.Common;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ConfigurationManager = StudentDorms.Settings.ConfigurationManager;
using AppSettings = StudentDorms.Settings.AppSettings;

namespace StudentDorms.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("Settings"));




            services.AddDatabase(Configuration);


            services.AddCors(options => options.AddPolicy("CorsPolicy",
             builder =>
             {
                 builder.WithOrigins("http://student-dorms.test")
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .AllowCredentials();
             }));
            //services.AddControllers(
            //        config => config.Filters.Add(typeof(ValidateModelAttribute))
            //    ).AddFluentValidation
            //    (fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateValidator>());

            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.Converters.Add(new DateTimeConverters());
            //});

            services.AddSingleton(AutoMapperConfiguration.Initialize());

            services.AddControllersWithViews(config =>
            {

            }).AddJsonOptions(opts =>
            {
                //opts.JsonSerializerOptions.PropertyNamingPolicy = null;
                opts.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });//.AddFluentValidation();


           

            services.AddRepositories();

            services.AddServices();

            services.AddServiceClients();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=OpenApi}/{action=VerifyConnection}").WithMetadata(new AllowAnonymousAttribute());
            });
        }
    }
}
