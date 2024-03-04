using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16_EF
{
    internal class ConnectionStringBuilderExample
    {
        public static void Example_Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-84M0NOK\\SQLEXPRESS";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "Hillel_HW15";
            builder.TrustServerCertificate = true;
            var conStr = builder.ConnectionString;

            using (var connection = new SqlConnection(conStr))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM dbo.Book";

                var reader = command.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t");
                }
                Console.WriteLine();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = reader.GetValue(i);
                        Console.Write(value.ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
