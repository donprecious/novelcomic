using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 


        [Required(ErrorMessage = "Password Required")]
        public  string Password { get; set; } 

        [Required(ErrorMessage = "Confirmation Password Required")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public  string ConfirmPassword { get; set; }
    }
}
