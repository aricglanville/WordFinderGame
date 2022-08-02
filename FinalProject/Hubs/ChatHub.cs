﻿using FinalProject.Services;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.Hubs
{
    public class ChatHub : Hub
    {
        public static Boolean enoughPlayers = false;
        public static string[] SecondBoard = new string[16];
                        
        public ApiClass apiClass { get; set; }

        public Boolean realWord;

        public static int count = 0;

        public async Task JoinGame(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            count++;
            var userName = Context.User.Identity.Name;
            await base.OnConnectedAsync();

            if (count >= 2)
            {   
                await Clients.All.SendAsync("ShowGrid");                
            }
            else
            {
                await Clients.All.SendAsync("HideGrid");
            }
        }

        public async Task CheckWord(string word)
        {
            var currentConnection = Context.ConnectionId;

            apiClass = new ApiClass(word);
            realWord = apiClass.check;

            if (realWord == true)
            {
                //TODO: add scoring stuff here?

                await Clients.Client(currentConnection).SendAsync("Correct");
            }
            else
            {
                //notify user
                await Clients.Client(currentConnection).SendAsync("NotAWord");
            }
        }
    }
}
