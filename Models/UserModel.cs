using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_registraion_EFW.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is Required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        [Compare("Password", ErrorMessage ="Password and Confirm-Password should be Same")]
        public string ConfirmPassword { get; set; }

        public DateTime Created_On { get; set; }
       
    }
}