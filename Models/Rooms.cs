using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebCloudCA.Models
{
    public class Rooms
    {
        public int RoomId { get; set; }

        [Required]
        public string RoomType { get; set; }
        public Decimal Price { get; set; }

        public List<Rooms> roomlist = new List<Rooms>();
        
    }
    
}