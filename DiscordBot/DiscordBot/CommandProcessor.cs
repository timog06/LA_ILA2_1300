using Discord;
using Discord.Commands;
using Discord.WebSocket;
using static filegrabber;
using System.Text;

namespace DiscordBot
{
    public class CommandProcessor
    {
        public Randomnumberguesser game;

        public void Choosing(SocketMessage arg)
        {
            string[] commandUS = arg.Content.Split('§');
            string[] command = commandUS[1].Split(' ');

            switch (command[0])
            {
                case "rnd":
                    var users = UserData.LoadUsers();
                    if (!users.ContainsKey(arg.Author.Id.ToString()))
                    {
                        users[arg.Author.Id.ToString()] = new User { id = arg.Author.Id.ToString(), username = arg.Author.Username, points = 0 };
                        UserData.SaveUser(users[arg.Author.Id.ToString()]);
                    }

                    StartNewGame();
                    arg.Channel.SendMessageAsync($"Successfully Created random number, you can guess now:");
                    break;
                case "g":
                    arg.Channel.SendMessageAsync(GuessProcessing(command[1], arg.Author));
                    break;
                case "highscore":
                    var user = UserData.LoadUsers().GetValueOrDefault(arg.Author.Id.ToString());
                    if (user != null)
                    {
                        arg.Channel.SendMessageAsync($"You have {user.points} points.");
                    }
                    else
                    {
                        arg.Channel.SendMessageAsync("You have no points recorded.");
                    }
                    break;
                case "highscorelist":
                    users = UserData.LoadUsers();
                    var topUsers = users.Values.OrderByDescending(u => u.points).Take(10).ToList();

                    var response = new StringBuilder("**Top 10 Users by Points:**\n");
                    int rank = 1;
                    foreach (var eachuser in topUsers)
                    {
                        response.AppendLine($"{rank}. {eachuser.username}: {eachuser.points} points");
                        rank++;
                    }

                    arg.Channel.SendMessageAsync(response.ToString());
                    break;
            }
        }

        void StartNewGame()
        {
            Random rnd = new();
            game = new() { randomNumber = rnd.Next(1, 101) };
        }

        string GuessProcessing(string guess, SocketUser author)
        {
            if (game == null)
            {
                return "Please initialise a game first.";
            }

            if (Convert.ToInt32(guess) < game.randomNumber)
            {
                return "Your number is too smol";
            }
            else if (Convert.ToInt32(guess) > game.randomNumber)
            {
                return "Your number is too big";
            }
            else
            {
                var user = UserData.LoadUsers().GetValueOrDefault(author.Id.ToString());
                if (user != null)
                {
                    user.points += 20;  // Adding 20 points
                    UserData.SaveUser(user);
                }
                game = null;
                return "Your number is Guud";
            }
        }
    }
}
