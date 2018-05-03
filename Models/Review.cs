using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class Review
    {
        [Required(ErrorMessage = "Missing Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Missing Booking Code")]
        public string BookingCode { get; set; }

        [Required(ErrorMessage = "Missing Review")]
        public string Comment { get; set; }
    }
}