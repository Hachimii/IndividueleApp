using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Models;
using FTHWebapp.Interfaces;
using FTHWebapp.Controllers;
using System.Data.SqlClient;
using System.Threading;
using System.Data;

namespace FTHWebapp.SqlContext
{
    public class ProjectSqlContext : Database, IProjectContext
    {
        //https://github.com/Hachimii/KillerApp.git github link
        private List<Project> Pj = new List<Project>();
        private List<Project> Pd = new List<Project>();
        private List<Project> T = new List<Project>();

        public void AddProject(Project P)
        {
            Openconnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("Addproject", Connection))
                {
                    cmd.Parameters.AddWithValue("ProjectId", P.ProjectId);
                    cmd.Parameters.AddWithValue("Name", P.Name);
                    cmd.Parameters.AddWithValue("Functions", P.Functions);
                    cmd.Parameters.AddWithValue("Minimumspots", P.Minimumspots);
                    cmd.Parameters.AddWithValue("Date", P.Date);
                    cmd.Parameters.AddWithValue("City", P.City);
                    cmd.Parameters.AddWithValue("Descpription", P.Description);
                    cmd.Parameters.AddWithValue("Type", P.Type);
                    cmd.Parameters.AddWithValue("Pictures", P.Pictures);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch 
            {

              
            }
        }
        public ProjectSqlContext()
        {
        }

        public void delete()
        {
         
        }

        public void FilterProjects()
        {
        }

        public List<Project> GetAllProjects()
        {
            
            Pj = new List<Project>();
            Openconnection();
            string query = "SELECT * FROM Project";
            SqlCommand cmd = new SqlCommand(query, Connection);

            using (SqlDataReader Reader = cmd.ExecuteReader())

                while (Reader.Read())
                {
                    Project P = new Project();
                    P.ProjectId = (int)(Reader["ProjectId"]);
                    P.Name = (string)(Reader["Name"]);
                    P.Functions = (int)(Reader["Functions"]);
                    P.Minimumspots = (int)(Reader)["Minimumspots"];
                    P.Date = (string)(Reader)["Date"];
                    P.City = (string)(Reader)["City"];
                    P.Type = (string)(Reader)["Type"];
                    P.Pictures = (string)(Reader)["Pictures"];
                   
                    Pj.Add(P);
                }

            CloseConnection();
            return Pj;
            
        }

        public void Delete(int id)
        {
            Openconnection();

            string query = "Delete From Project Where ProjectId = @ProjectId";

            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@ProjectId", id);
                cmd.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Edit(Project p)
        {
            Openconnection();
            string query = "Update Project SET Name = @Name, Functions = @Functions, Minimumspots = @Minimumspots, Date = @Date, City = @City, Type = @Type, Description = @Description Where ProjectId = @ProjectId";

            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Functions", p.Functions);
                cmd.Parameters.AddWithValue("@Minimumspots", p.Minimumspots);
                cmd.Parameters.AddWithValue("@Date", p.Date);
                cmd.Parameters.AddWithValue("@City", p.City);
                cmd.Parameters.AddWithValue("@Type", p.Type);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@ProjectId", p.ProjectId);

                cmd.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public List<Project> GetTypes()
        {
            T = new List<Project>();
            Openconnection();

            string query = "Select Type from Project";
            SqlCommand cmd = new SqlCommand(query, Connection);

            using (SqlDataReader r = cmd.ExecuteReader())

                while (r.Read())
                {
                    Project p = new Project();
                    p.Type = (string)(r["Type"]);

                    T.Add(p);
                }

            return T;

        }
        public Project GetDetails(int projectid)
        {
            Project P = new Project();
            Openconnection();

            string query = "Select * from Project WHERE ProjectId = @projectid";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@projectid", projectid);
            using (SqlDataReader R = cmd.ExecuteReader())
                while (R.Read())
                {
                    P.ProjectId = (int)(R["ProjectId"]);
                    P.Name = (string)(R["Name"]);
                    P.Functions = (int)(R["Functions"]);
                    P.Minimumspots = (int)(R["Minimumspots"]);
                    P.Date = (string)(R["Date"]);
                    P.Description = (string)(R["Description"]);
                    P.Type = (string)(R["Type"]);
                    P.City = (string)(R["City"]);
                    P.Pictures = (string)(R["Pictures"]);

                }

            CloseConnection();
            return P;
        }

    }
}

