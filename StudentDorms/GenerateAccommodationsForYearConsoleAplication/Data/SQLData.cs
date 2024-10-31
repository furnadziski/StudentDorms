using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentDorms.AccommodationsGenerator.Models;
using System;
using System.Configuration;
using System.Data;
using System.IO;

namespace StudentDormsAccommodationsGenerator.Data
{
    public static class SQLData
    {
        private static readonly ILog _log = log4net.LogManager.GetLogger(typeof(Program));
        public static SqlConnection GetConnection
        {
            get
            {
                try
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();

                    IConfiguration configuration = builder.Build();

                    var settings = configuration.GetSection("Settings").Get<AppSettings>();

                    SqlConnection connection = new SqlConnection(settings.ConnectionString);
                    connection.Open();
                    return connection;
                }
                catch (Exception exception)
                {
                    throw;
                }

            }

        }

        private static void CloseConnection(SqlConnection connection)
        {
            try { connection.Close(); }
            catch { Exception exception; }

            try { connection.Dispose(); }
            catch { Exception exception; }
        }


        public static void GenerateAccommodationsForYear(int Year)
        {
            SqlConnection connection = null;
            try
            {
                connection = GetConnection;
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[accommodation].[GenerateAccommodationsForYear]";
                command.Connection = connection;

                SqlParameter yearParameter = null;
                yearParameter = new SqlParameter();
                  yearParameter.Direction = ParameterDirection.Input;
                yearParameter.SqlDbType = SqlDbType.Int;
              
                yearParameter.ParameterName = "@Year";
                yearParameter.Value = Year;
                command.Parameters.Add(yearParameter);

                command.ExecuteNonQuery();
            }
            catch(Exception exception)
            {
                _log.Error(exception);
            }
            finally
            {
                CloseConnection(connection);
            }
        }

    }
}
