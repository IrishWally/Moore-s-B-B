using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must enter an email address")]
        [EmailAddress(ErrorMessage = "Your email address is invalid")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a valid password")]
        [StringLength(10, ErrorMessage = "Password must contain at least 6 characters a-z and at least 1 number 0-9", MinimumLength = 6)]
        public string Password { get; set; }

        public Role UserRole { get; set; }






    }
}