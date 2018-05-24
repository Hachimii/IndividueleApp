using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FTHWebapp.Models;


namespace FTHWebapp.ViewModels
{
    public class ProjectViewModel
    {
     
        public List<Project> Project { get; set; }
        public ProjectViewModel(List<Project> Project)
        {
            this.Project = Project;
        }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Number of functions")]
        public string Functions { get; set; }

        [Required(ErrorMessage = "Give a minimum to start project")]
        public string Minimumspots { get; set; }

        [Required][DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Phonenumber required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Description for project required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type of project required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Imagepath required")]
        public string Pictures { get; set; }

    }
}