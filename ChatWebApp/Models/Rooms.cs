using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
