
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.ViewModels
{
    public class UserVM
    {
        public List<Row> rows { get; set; }
        public List<UserRow> UserRows { get; set; }

        public string LogUser { get; set; }
        public int userId { get; set; }

        public class Row
        {
            public DateTime DateTimeMessage { get; set; }
            public string message { get; set; }
            public string username { get; set; }
            public string roomName { get; set; }
        }

        public class UserRow
        {
           public string userName { get; set; }
            public int userId { get; set; }
        }
    }
}
