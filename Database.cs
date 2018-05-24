using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FTHWebapp
{
    public class Database
    {
        public SqlConnection Connection;
        public string UserID;
        public string Password;
        public string DB;
        public string Server;



        public bool Openconnection()
        {

            string connectionString = "Server=mssql.fhict.local;Database=dbi383927;User Id=dbi383927;Password=Huiswerk1-";

            Connection = new SqlConnection(connectionString);

            try
            {
                Connection.Open();
                return true;

            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (SqlException)
            {

                return false;
            }
        }

    }
}
