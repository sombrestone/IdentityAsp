using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login is not specified")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is not specified")]
        public string Password { get; set; }
    }
}
