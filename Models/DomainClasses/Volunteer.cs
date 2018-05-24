using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FTHWebapp.SqlContext;
using FTHWebapp.Interfaces;
using FTHWebapp.Controllers;
using FTHWebapp.Models.DomainClasses;
using Microsoft.Extensions.Primitives;

namespace FTHWebapp.Models
{
    public class Volunteer
    {
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Birthdate { get; set; }
        public string Experience { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<Role> Rollen { get; set; }

        public Volunteer(string name, string address, string birthdate, string experience, string phonenumber, string email, string username, string password, string city, int roleID, string roleName)
        {
            Name = name;
            Address = address;
            Birthdate = birthdate;
            Experience = experience;
            Phonenumber = phonenumber;
            Email = email;
            Username = username;
            Password = password;
            City = city;
            RoleID = roleID;
            RoleName = roleName;           
        }

        public Volunteer()
        {

        }

        public Volunteer(string name, string username, string email/*, List<Role> rol*/)
        {
            Name = name;
            Username = username;
            Email = email;
            //Rollen = rol;

        }
    }
}
