using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Missing First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Missing Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Missing Email")]
        public string Email { get; set; }

        [StringLength(1000, ErrorMessage = "Comment too large")]
        public string Query { get; set; }



    }
}