using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTHWebapp.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(4), MaxLength(20), Display(Name = "Username")]
        public string Username { get; set; }

        [Required, MinLength(4), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
