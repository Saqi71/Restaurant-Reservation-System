using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe_Szechuan;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe_Szechuan
{
    public static class DatabaseConnection
    {
        private static string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}

