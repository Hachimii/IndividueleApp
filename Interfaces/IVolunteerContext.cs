using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.SqlContext;
using FTHWebapp.Models;
using FTHWebapp.Controllers;

namespace FTHWebapp.Interfaces
{
    public interface IVolunteerContext
    {
        void AddVolunteer(Volunteer V);
        void Edit(Volunteer volunteer);
        List<Volunteer> AddRoles();
        Volunteer Gebruiker(string username, string password);
        void Checkpasswoord();
        Volunteer GetDetails(int id);
        void Checkinput();
        void Delete(int id);
    }
}
