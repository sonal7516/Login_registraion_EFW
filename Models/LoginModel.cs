using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_registraion_EFW.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email Address is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Address is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}