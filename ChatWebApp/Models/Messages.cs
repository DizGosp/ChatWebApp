using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Models
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }

        public string Message { get; set; }

        public DateTime DateAndTime { get; set; }



        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }


        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Rooms Room { get; set; }
    }
}
