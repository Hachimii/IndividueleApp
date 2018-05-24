using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Interfaces;
using FTHWebapp.Models.DomainClasses;

namespace FTHWebapp.Context
{
    public class RoleSqlContext : Database, IRoleContext
    {
        private List<Role> Rollen = new List<Role>();
        public List<Role> GetAllRoles()
        {
            Rollen = new List<Role>();
            Openconnection();
            string query = "SELECT * FROM Function";
            SqlCommand cmd = new SqlCommand(query, Connection);

            using (SqlDataReader Reader = cmd.ExecuteReader())

                while (Reader.Read())
                {
                    Role R = new Role();
                    R.FunctionID = (int)(Reader["FunctionID"]);
                    R.Name = (string)(Reader)["Name"];
                    Rollen.Add(R);
                }

            return Rollen;

        }
    }
}
