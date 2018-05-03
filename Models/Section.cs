using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class Section
    {
        [Required]
        public string Heading { get; set; }

        [Required]
        public string Descriptiuon { get; set; }

    }
}