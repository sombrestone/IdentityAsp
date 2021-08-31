using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.ViewModels
{
    public class RegisterViewModel: LoginViewModel
    {
        [Required(ErrorMessage = "Email is not specified")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
