using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.ViewModels
{
    public class DataSave
    {
        public int userId { get; set; }
        public int roomId { get; set; }
        public DateTime date { get; set; }
       public string message { get; set; }
    }
}
