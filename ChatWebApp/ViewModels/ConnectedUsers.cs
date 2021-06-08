using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.ViewModels
{
    public class ConnectedUsers
    {
      public static List<string> Ids = new List<string>();

        public int userId { get; set; }
        public string userName { get; set; }

        public bool isOnline { get; set; }

    }
}
