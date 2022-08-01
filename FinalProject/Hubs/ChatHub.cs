using Microsoft.AspNetCore.SignalR;

namespace FinalProject.Hubs
{
    public class ChatHub : Hub
    {
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

            if (count == 2)
            {
                
                await Clients.All.SendAsync("ShowGrid");
                
            }
            else
            {
                await Clients.All.SendAsync("HideGrid");
            }
        }
    }
}
