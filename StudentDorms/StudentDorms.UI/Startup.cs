using StudentDorms.Configuration;
using StudentDorms.Middlewares;
using StudentDorms.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using AppSettings = StudentDorms.Settings.AppSettings;

namespace StudentDorms.UI
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

            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/ClientApp";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            })
           
            .UseDefaultFiles(options)
            .UseStaticFiles();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            //app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}").WithMetadata(new AllowAnonymousAttribute());
            });
        }
    }
}
