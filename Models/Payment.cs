using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebCloudCA.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        //^[a-zA-Z]+$
        [Display(Name = "Name on Card")]
        [Required(ErrorMessage = "Name on Card is required in order to proceed with the registration")]
       // [RegularExpression(@"/([\p{L}'-]+) ([\p{L}'-]+)/", ErrorMessage = "Proper first names contain only letters from a-z. No Nicknames allowed")]
        public string CardHolderName { get; set; }

        [Display(Name = "Type of Card")]
        [Required(ErrorMessage = "Name must match your card provider name exactly")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Error, Card Type must only contain letters from A-Z")]
        public string CardType { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Number is invalid")]
        //insert regex for cards
        public string CardNumber { get; set; }

        [Display(Name = "Security Number")]
        [Required(ErrorMessage = "Security number must be 3 digits long")]
        [RegularExpression(@"^\d{3}$")]
        public int SecurityNum { get; set; }

        [Display(Name = "Expiry Month")]
        [Required(ErrorMessage = "Invalid Expiry  Month, ")]
        [RegularExpression("^(\\d|(1[0-2]))$")]
        public int ExpMon { get; set; }

        [Display(Name = "Expiry Year")]
        [Required(ErrorMessage = "Invalid Expiry Year, ")]
        [RegularExpression("^(\\d|([0-9][0-9]))$")]
        public int ExpYr { get; set; }

        [Display(Name ="Amount")]
        [Required(ErrorMessage = "Must be a valid amount")]
       // [RegularExpression(@"^\d{3}$")]
        public decimal Amount { get; set; }

        public int BookingId { get; set; }


    }
}