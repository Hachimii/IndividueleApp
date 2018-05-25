using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FTHWebapp.Models.DomainClasses;
using FTHWebapp.Models;

namespace FTHWebapp.ViewModels
{
    public class VolunteerViewModel
    {
        public Volunteer V { get; set; }
        public List<Volunteer> Volunteer { get; set; }
        public VolunteerViewModel(List<Volunteer> Volunteer)
        {
            this.Volunteer = Volunteer;
        }

        public VolunteerViewModel(Volunteer v)
        {
        }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adress required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Birthdate required")]
        public string Birthdate { get; set; }

        public string Experience { get; set; }
        [Required(ErrorMessage = "Phonenumber required")]
        [DataType(DataType.PhoneNumber)]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Emailadress required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username required, min length 4 characters"), MinLength(4)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "City required")]
        public string City { get; set; }
        [Required()]
        public int RoleID { get; set; }


    }
}
