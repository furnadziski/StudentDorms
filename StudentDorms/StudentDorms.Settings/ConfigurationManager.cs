using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Settings
{
    public static class ConfigurationManager
    {
        private static DatabaseSettings _databaseSettings;
        private static AppSettings _appSettings;


        public static DatabaseSettings DatabaseSettings
        {
            get
            {
                if (_databaseSettings == null)
                {
                    _databaseSettings = GetCurrentDatabaseSettings();
                }

                return _databaseSettings;
            }
        }

        public static DatabaseSettings GetCurrentDatabaseSettings()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var settings = configuration.GetSection("Database").Get<DatabaseSettings>();

            return settings;
        }


        public static AppSettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = GetCurrentAppSettings();
                }

                return _appSettings;
            }
        }

        public static AppSettings GetCurrentAppSettings()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var settings = configuration.GetSection("Settings").Get<AppSettings>();

            return settings;
        }
    }
}
