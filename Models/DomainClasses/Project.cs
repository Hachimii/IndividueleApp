using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTHWebapp.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Functions { get; set; }
        public int Minimumspots { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Pictures { get; set; }

        public Project(string name, int functions, int minimumspots, string date, string city, string description, string type, string pictures)
        {

            Name = name;
            Functions = functions;
            Minimumspots = minimumspots;
            Date = date;
            City = city;
            Description = description;
            Type = type;
            Pictures = pictures;

        }
        public Project()
        {


        }
    }
}
