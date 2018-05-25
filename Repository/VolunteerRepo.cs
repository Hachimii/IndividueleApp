using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Interfaces;
using FTHWebapp.Models;
using FTHWebapp.Models.DomainClasses;

namespace FTHWebapp.Repository
{
    public class VolunteerRepo: IVolunteerContext
    {
        private readonly IVolunteerContext _context;
        public VolunteerRepo(IVolunteerContext context)
        {
            _context = context;
        }

        public Volunteer GetGebruiker(string username, string password)
        {
           return _context.Gebruiker(username, password);
        }
        public void AddVolunteer(Volunteer V)
        {
            _context.AddVolunteer(V);
        }
        public void Edit (Volunteer volunteer)
        {
            _context.Edit(volunteer);
        }
        public void Delete(int id)
        {
 
            _context.Delete(id);
        }

        public List<Volunteer> AddRoles()
        {
           return  _context.AddRoles();
        }
        
        public Volunteer GetDetails(int id)
        {
            return _context.GetDetails(id);
        }
        public void Checkpasswoord()
        {
            throw new NotImplementedException();
        }

        public Volunteer Gebruiker(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Checkinput()
        {
            throw new NotImplementedException();
        }
    }
}
