using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbTest
{
    class Program
    {
        private static string _connectionString;
        private static SqlConnection _connection;


        static void Main(string[] args)
        {

            _connectionString = ConfigurationManager.ConnectionStrings["DbTest.Properties.Settings.Database_Test01ConnectionString"].ConnectionString;


            PopulatePersons();

            Console.ReadKey();
        }



        private static void PopulatePersons()
        {
            string sqlQuery = "SELECT * FROM Person";



            using (_connection = new SqlConnection(_connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _connection))
            {
                {
                    DataTable personTable = new DataTable();

                    adapter.Fill(personTable);


                }


            }

        }




    }
}
