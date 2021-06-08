using ChatWebApp.EF;
using ChatWebApp.Hubs;
using ChatWebApp.Models;
using ChatWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Controllers
{
    public class HomeController : Controller
    {
        private int LoggedUser = 0;
        private readonly ILogger<HomeController> _logger;
        private MyContext _db;
        private readonly IHubContext<ChatHub> _connectedUsers;
        public HomeController(MyContext context, ILogger<HomeController> logger, IHubContext<ChatHub> connUsers)
        {
            _db = context;
            _logger = logger;
            _connectedUsers = connUsers;
        }

        public static string GenereteUserName(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public IActionResult Index()
        {


            ViewBag.number = ConnectedUsers.Ids;

            Users us = new Users
            {
                UserName = GenereteUserName()
            };

            _db.User.Add(us);
            _db.SaveChanges();

            LoggedUser = us.UserId;

            UserVM model = new UserVM();
            model.userId = us.UserId;
            model.LogUser = us.UserName;
            model.rows = _db.Message
           .Where(n => n.RoomId == 6)
           .Include(u => u.User)
           .Include(r => r.Room)
            .Select(n => new UserVM.Row
            {
                username = n.User.UserName,
                message = n.Message,
                DateTimeMessage = DateTime.Now,
                roomName = n.Room.Name
            }).ToList();


            return View(model);
        }

        public  bool SaveMess(DataSave model) 
        {
            if (model != null)
            {
                Messages m = new Messages
                {
                    Message = model.message,
                    DateAndTime = model.date,
                    RoomId = model.roomId,
                    UserId = model.userId
                };
                 _db.Message.Add(m);
                 _db.SaveChanges();
                return true;
            }

            return false;

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
