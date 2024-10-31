using System;
using System.Data.SqlClient;
namespace StudentDorms.Tools.Data
public static class SQLData
{
    private static void OpenSqlConnection()
    {
        string connectionString = GetConnectionString();

        using (SqlConnection connection = new SqlConnection())
        {
            connection.ConnectionString = connectionString;

            connection.Open();

            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("ConnectionString: {0}",
                connection.ConnectionString);
        }
    }
}
