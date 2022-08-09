using FinalProject.Services;
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

        public static List<string> connectionIDS = new List<string>();

        public static List<string> user1Words = new List<String>();

        public static List<string> user2Words = new List<String>();

        public static int user1Score = 0;

        public static int user2Score = 0;

        //public static Dictionary<string, int> userScores = new Dictionary<string, int>();

        public async Task JoinGame(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            count++;

            await base.OnConnectedAsync();
            connectionIDS.Add(Context.ConnectionId);
            //userScores.Add(Context.ConnectionId, 0);

            if(count < 2)
            {
                await Clients.All.SendAsync("HideGrid");
            }
            else if (count == 2)
            {   
                await Clients.All.SendAsync("ShowGrid");                
            }
            else
            {
                await Clients.Caller.SendAsync("GameFull");
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("PlayerDisconnected");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task CheckWord(string word)
        {
            var currentConnection = Context.ConnectionId;
            //var currentScore = userScores[Context.ConnectionId];

            apiClass = new ApiClass(word);
            realWord = apiClass.check;

            if (realWord == true)
            {
                if (word.Length == 3)
                {
                    AddScoreAndWord(currentConnection, word, 1);
                }
                else if (word.Length == 4)
                {
                    AddScoreAndWord(currentConnection, word, 2);
                }
                else if (word.Length == 5)
                {
                    AddScoreAndWord(currentConnection, word, 4);
                }
                else if (word.Length == 6)
                {
                    AddScoreAndWord(currentConnection, word, 6);
                }
                else if (word.Length == 7)
                {
                    AddScoreAndWord(currentConnection, word, 8);
                }
                else if (word.Length == 8)
                {
                    AddScoreAndWord(currentConnection, word, 10);
                }
                else if (word.Length >= 9)
                {
                    AddScoreAndWord(currentConnection, word, 15);
                }
                await Clients.Client(currentConnection).SendAsync("Correct", user1Score, user2Score);
                await Clients.All.SendAsync("UpdateScores", user1Score, user2Score);
            }
            else
            {
                //notify user
                await Clients.Client(currentConnection).SendAsync("NotAWord");
            }
        }

        public async Task GameOver()
        {
            await Clients.All.SendAsync("DisplayScores", user1Score, user2Score, user1Words, user2Words);
        }

        public async Task ResetGame()
        {
            count = 0;
            user1Score = 0;
            user2Score = 0;
            user1Words.Clear();
            user2Words.Clear();
            Array.Clear(SecondBoard);
            enoughPlayers = false;

            await Clients.All.SendAsync("NewGame");
        }

        private void AddScoreAndWord(string connectionID, string word, int score)
        {
            if (Context.ConnectionId == connectionIDS[0])
            {
                user1Words.Add(word);
                user1Score += score;
            }
            else if(Context.ConnectionId == connectionIDS[1])
            {
                user2Words.Add(word);
                user2Score += score;
            }
        }
    }
}
