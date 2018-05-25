using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Models;
using FTHWebapp.Interfaces;
using FTHWebapp.Controllers;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using FTHWebapp.Models.DomainClasses;

namespace FTHWebapp.SqlContext
{
    public class VolunteerSqlContext : Database, IVolunteerContext, IUserStore<Volunteer>, IUserPasswordStore<Volunteer>, IUserEmailStore<Volunteer>, IUserRoleStore<Volunteer>
    {
        public Task AddToRoleAsync(Volunteer user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Volunteer Gebruiker(string Username, string Password)
        {
            List<Role> Rollen = new List<Role>();
            Volunteer GB = default(Volunteer);
            Openconnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("Login", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    SqlDataReader Read = cmd.ExecuteReader();


                    while (Read.Read())
                    {
                        string username = (string)(Read["Username"]);
                        string email = (string)(Read["Email"]);
                        string name = (string)(Read["Name"]);
                        //string role = (string)(Read)["Rolnaam"];
                        //Role rol = new Role(role);
                        //Rollen.Add(rol);

                        GB = new Volunteer(name, username, email/*, Rollen*/);
                    }
                    CloseConnection();
                }
                return GB;
            }
            catch
            {
                throw;
            }

        }
        public void AddVolunteer(Volunteer vv)
        {
            Openconnection();
            try
            {
                using (SqlCommand Cmd = new SqlCommand("Register", Connection))
                {
                    Cmd.Parameters.AddWithValue("@Name", vv.Name);
                    Cmd.Parameters.AddWithValue("@Address", vv.Address);
                    Cmd.Parameters.AddWithValue("@Birthdate", vv.Birthdate);
                    Cmd.Parameters.AddWithValue("@Experience", vv.Experience);
                    Cmd.Parameters.AddWithValue("@Phonenumber", vv.Phonenumber);
                    Cmd.Parameters.AddWithValue("@Email", vv.Email);
                    Cmd.Parameters.AddWithValue("@Username", vv.Username);
                    Cmd.Parameters.AddWithValue("@Password", vv.Password);
                    Cmd.Parameters.AddWithValue("@City", vv.City);
                    Cmd.Parameters.AddWithValue("RoleID", vv.RoleID);

                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.ExecuteNonQuery();
                    CloseConnection();

                }

            }
            catch
            {

            }
        }

        public void Delete(int personalid)
        {
            Openconnection();

            string query = "Delete FROM Volunteer WHERE PersonalId = @personalid";

            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {

                cmd.Parameters.AddWithValue("@PersonalId", personalid);
                cmd.ExecuteNonQuery();

            }

            CloseConnection();
        }
            
            public Volunteer GetDetails(int personalid)
            {
                Volunteer V = new Volunteer();
                Openconnection();

                string query = "Select PersonalId, Name, Address, Birthdate, Experience, Phonenumber, Email, Username, City From Volunteer WHERE PersonalId = @personalid";
                SqlCommand cmd = new SqlCommand(query, Connection);
                cmd.Parameters.AddWithValue("@personalid", personalid);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        V.PersonalId = (int)(reader["PersonalId"]);
                        V.Name = (string)(reader["Name"]);
                        V.Address = (string)(reader)["Address"];
                        V.Birthdate = (string)(reader)["Birthdate"];
                        V.Experience = (string)(reader)["Experience"];
                        V.Phonenumber = (string)(reader["Phonenumber"]);
                        V.Email = (string)(reader["Email"]);
                        V.Username = (string)(reader["Username"]);
                        V.City = (string)(reader["City"]);

                    }

                    CloseConnection();
                    return V;
                }

            }



            public void Edit(Volunteer V)
            {
                Openconnection();

                string query = "Update Volunteer SET Name = @Name, Address = @Address, Birthdate = @Birthdate, Experience = @Experience, Phonenumber = @Phonenumber, Email = @Email, Username = @Username, City = @City  Where PersonalId = @personalid";


                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Name", V.Name);
                    cmd.Parameters.AddWithValue("@Address", V.Address);
                    cmd.Parameters.AddWithValue("@PersonalId", V.PersonalId);
                    cmd.Parameters.AddWithValue("@Birthdate", V.Birthdate);
                    cmd.Parameters.AddWithValue("@Experience", V.Experience);
                    cmd.Parameters.AddWithValue("@Phonenumber", V.Phonenumber);
                    cmd.Parameters.AddWithValue("@Email", V.Email);
                    cmd.Parameters.AddWithValue("@Username", V.Username);
                    cmd.Parameters.AddWithValue("@City", V.City);

                    cmd.ExecuteNonQuery();


                }



                CloseConnection();

            }



            public List<Volunteer> AddRoles()
            {
                List<Volunteer> Vol = new List<Volunteer>();
                Openconnection();
                string query = "SELECT Volunteer.PersonalId, Volunteer.Name, Volunteer.Username, Role.Name AS RName, Volunteer.RoleID, Role.RoleID AS RolesID FROM Volunteer INNER JOIN Role ON Volunteer.RoleID = Role.RoleID";
                SqlCommand cmd = new SqlCommand(query, Connection);

                using (SqlDataReader Reader = cmd.ExecuteReader())
                    while (Reader.Read())
                    {
                        Volunteer V = new Volunteer();
                        V.PersonalId = (int)(Reader["PersonalId"]);
                        V.Name = (string)(Reader["Name"]);
                        V.Username = (string)(Reader["Username"]);
                        V.RoleID = (int)(Reader)["RolesID"];
                        V.RoleName = (string)(Reader)["RName"];

                        Vol.Add(V);
                    }

                return Vol;



            }
            public void Checkinput()
            {
                throw new NotImplementedException();
            }

            public void Checkpasswoord()
            {
                throw new NotImplementedException();
            }

            public Task<IdentityResult> CreateAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<IdentityResult> DeleteAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public Task<Volunteer> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<Volunteer> FindByIdAsync(string userId, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<Volunteer> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetEmailAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<bool> GetEmailConfirmedAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetNormalizedEmailAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetNormalizedUserNameAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetPasswordHashAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<IList<string>> GetRolesAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetUserIdAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<string> GetUserNameAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<IList<Volunteer>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<bool> HasPasswordAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<bool> IsInRoleAsync(Volunteer user, string roleName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task RemoveFromRoleAsync(Volunteer user, string roleName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetEmailAsync(Volunteer user, string email, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetEmailConfirmedAsync(Volunteer user, bool confirmed, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetNormalizedEmailAsync(Volunteer user, string normalizedEmail, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetNormalizedUserNameAsync(Volunteer user, string normalizedName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetPasswordHashAsync(Volunteer user, string passwordHash, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task SetUserNameAsync(Volunteer user, string userName, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<IdentityResult> UpdateAsync(Volunteer user, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public void UpdateVolunteer(Volunteer V)
            {
                throw new NotImplementedException();
            }

        }
    }
