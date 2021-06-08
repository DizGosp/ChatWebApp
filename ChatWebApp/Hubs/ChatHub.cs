using ChatWebApp.Models;
using ChatWebApp.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",username, message);
        }

        public async Task SendMessageToUser(string username,string message) 
        {
            await  Clients.Client(username).SendAsync("ReceiveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            ConnectedUsers.Ids.Add(Context.ConnectionId);
             return base.OnConnectedAsync();
        }

        public override  Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUsers.Ids.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
