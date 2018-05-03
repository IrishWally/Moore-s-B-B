using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class Customer
    {

        public int Customerid { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required in order to proceed with the registration")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Proper first names contain only letters from a-z. No Nicknames allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required in order to proceed with the registration")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Proper last names contain only letters from a-z. No Nicknames allowed")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required in order to proceed with the registration")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "A propper email address looks something like this: im2cool4school@host.com")]
       public string Email { get; set; }


        [Display(Name = "Phone")]
        [Required(ErrorMessage = "A phone number is required in order to proceed with the registration")]
       public string Phone { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "An Address is required in order to proceed with the registration")]
         public string Address { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A Password is required in order to proceed with the registration")]
        [StringLength(10, ErrorMessage = "Password must contain 6 to 10 characters. Internet protection is important!", MinimumLength = 6)]
      public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

        public List<Section> Review {get;set;}

    }
}