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
            var guildUser = arg.Author as SocketGuildUser;
            string displayName = guildUser?.Nickname ?? arg.Author.Username;

            string[] commandUS = arg.Content.Split('§');
            string[] command = commandUS[1].Split(' ');

            switch (command[0])
            {
                case "rnd":
                    var users = UserData.LoadUsers();
                    if (!users.ContainsKey(arg.Author.Id.ToString()))
                    {
                        users[arg.Author.Id.ToString()] = new User
                        {
                            id = arg.Author.Id.ToString(),
                            username = arg.Author.Username,
                            displayname = displayName,
                            points = 0
                        };
                        UserData.SaveUser(users[arg.Author.Id.ToString()]);
                    }

                    StartNewGame();
                    arg.Channel.SendMessageAsync($"Successfully Created random number, you can guess now:");
                    break;
                case "g":
                    arg.Channel.SendMessageAsync(GuessProcessing(command[1], arg.Author));
                    break;
                case "highscore":
                    var targetUser = UserData.LoadUsers().GetValueOrDefault(ParseUserId(command, arg));

                    if (targetUser != null)
                    {
                        arg.Channel.SendMessageAsync($"{targetUser.displayname} has {targetUser.points} points.");
                    }
                    else
                    {
                        arg.Channel.SendMessageAsync("User has no points recorded.");
                    }
                    break;
                case "highscorelist":
                    users = UserData.LoadUsers();
                    var topUsers = users.Values.OrderByDescending(u => u.points).Take(10).ToList();

                    var response = new StringBuilder("**Top 10 Users by Points:**\n");
                    int rank = 1;
                    foreach (var eachuser in topUsers)
                    {
                        response.AppendLine($"{rank}. {eachuser.displayname}: {eachuser.points} points"); 
                        rank++;
                    }

                    arg.Channel.SendMessageAsync(response.ToString());
                    break;
                case "help":
                    var helpMessage = new EmbedBuilder()
                    {
                        Title = "Number Guesser Commands helps",
                        Description = "This is a list for all available commands.",
                        Color = Color.Purple
                    };

                    helpMessage.AddField("§rnd", "Generate a random number.");
                    helpMessage.AddField("§g", "Guess the generated number.");
                    helpMessage.AddField("§highscore", "Show your own highscore.");
                    helpMessage.AddField("§highscore @user", "Show the highscore of the mentioned user.");
                    helpMessage.AddField("§highscorelist", "Show the Top 10 highscores on this server.");
                    helpMessage.AddField("§help", "Show this list.");

                    arg.Channel.SendMessageAsync(embed: helpMessage.Build());
                    break;
            }
        }
        string ParseUserId(string[] unParsedUserID, SocketMessage arg)
        {

            if (unParsedUserID.Length > 1 && unParsedUserID[1].StartsWith("<@") && unParsedUserID[1].EndsWith(">"))
            {
                return unParsedUserID[1].TrimStart('<', '@', '!').TrimEnd('>');
            }
            else
            {
                return arg.Author.Id.ToString();
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
                    user.points += 20; 
                    UserData.SaveUser(user);
                }
                game = null;
                return "Your number is Guud";
            }
        }
    }
}
