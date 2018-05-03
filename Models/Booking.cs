using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{


    public class Booking
    {
       // [Required(ErrorMessage = "Missing First Name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Missing Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Missing Email")]
        public string Email { get; set; }

       // [Required(ErrorMessage = "Missing Phone Number")]
        public string Phone { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Missing Arrival Date")]
        [Display(Name ="Arrival Date")]
        [DataType(DataType.DateTime,ErrorMessage ="Invalid Date")]
        public DateTime ArrivalDate { get; set; }

        [Required(ErrorMessage = "Missing Departure Date")]
        [Display(Name = "Departure Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Date")]
        public DateTime DepartureDate { get; set; }


        [Display(Name = "Number Of Nights")]
        public int Nights { get; set; }

        //supplied 
        public Decimal Price { get; set; }

        //review is optional
        public List<Section> Review { get; set; }

        //properties for displaying in SHOW ALL
        public string PaymentMade { get; set; }
        public int CustomerId { get; set; }
        public string RoomType { get; set; }
        public int BookingId { get; set; }






    }
}