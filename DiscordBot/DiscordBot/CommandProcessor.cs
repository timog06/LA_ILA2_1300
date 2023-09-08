using Discord;
using Discord.WebSocket;
using System.Text;
using static filegrabber;

namespace DiscordBot
{
    public class CommandProcessor
    {
        public Randomnumberguesser game;


        public void Choosing(SocketMessage arg, SocketGuild guild)
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

                    StartNewGame(command);
                    arg.DeleteAsync();
                    var randomNumber = new EmbedBuilder();
                    randomNumber.WithDescription($"Successfully Created random number, you can guess now:");
                    randomNumber.WithColor(Color.Purple);
                    arg.Channel.SendMessageAsync("", false, randomNumber.Build());
                    break;
                case "g":
                    var guess = new EmbedBuilder();
                    guess.WithColor(Color.Purple);
                    guess.WithDescription(GuessProcessing(command[1], arg.Author, guild));
                    arg.Channel.SendMessageAsync("", false, guess.Build());


                    break;
                case "highscore":
                    var targetUser = UserData.LoadUsers().GetValueOrDefault(ParseUserId(command, arg));

                    if (targetUser != null)
                    {
                        var userhighscore = new EmbedBuilder();
                        userhighscore.WithColor(Color.Purple);
                        userhighscore.WithDescription($"{targetUser.displayname} has {targetUser.points} points.");
                        arg.Channel.SendMessageAsync("", false, userhighscore.Build());
                    }
                    else
                    {
                        var userhighscore = new EmbedBuilder();
                        userhighscore.WithColor(Color.Purple);
                        userhighscore.WithDescription("User has no points recorded.");
                        arg.Channel.SendMessageAsync("", false, userhighscore.Build());
                    }
                    break;
                case "highscorelist":
                    users = UserData.LoadUsers();
                    var topUsers = users.Values.OrderByDescending(u => u.points).Take(10).ToList();

                    var topUsersMessage = new EmbedBuilder()
                    {
                        Title = "Top 10 Users by Points",
                        Description = "Here are the top 10 users by points:",
                        Color = Color.Purple
                    };

                    int rank = 1;
                    foreach (var eachuser in topUsers)
                    {
                        topUsersMessage.AddField($"{rank}. {eachuser.displayname}", $"{eachuser.points} points");
                        rank++;
                    }

                    topUsersMessage.WithFooter("®Number Guesser Bot - 2023");

                    arg.Channel.SendMessageAsync(embed: topUsersMessage.Build());
                    break;
                case "help":
                    var helpMessage = new EmbedBuilder()
                    {
                        Title = "Number Guesser Commands help",
                        Description = "This is a list for all available commands.",
                        Color = Color.Purple
                    };

                    helpMessage.AddField("§rnd", "Generate a random number.");
                    helpMessage.AddField("§rnd ```||number||```", "Make your own number for others to guess.");
                    helpMessage.AddField("§g", "Guess the generated number.");
                    helpMessage.AddField("§highscore", "Show your own highscore.");
                    helpMessage.AddField("§highscore @user", "Show the highscore of the mentioned user.");
                    helpMessage.AddField("§highscorelist", "Show the Top 10 highscores on this server.");
                    helpMessage.AddField("§help", "Show this list.");
                    helpMessage.WithFooter("®Number Guesser Bot - 2023");

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
        void StartNewGame(string[] number)
        {
            try
            {
                if (number[1] != null)
                {
                    game = new() { randomNumber = ParseNumberBetweenBars(number[1]) };
                }
            }
            catch
            {
                Random rnd = new();
                game = new() { randomNumber = rnd.Next(1, 101) };
            }


        }
        static int ParseNumberBetweenBars(string input)
        {
            int startIndex = input.IndexOf("||") + 2;
            int endIndex = input.LastIndexOf("||");

            if (startIndex >= 0 && endIndex >= 0 && endIndex > startIndex)
            {
                string numberStr = input.Substring(startIndex, endIndex - startIndex);
                if (int.TryParse(numberStr, out int parsedNumber))
                {
                    return parsedNumber;
                }
            }

            throw new ArgumentException("Invalid input format.");
        }

        string GuessProcessing(string guess, SocketUser author, SocketGuild guild)
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
                    RoleManager roleManager = new RoleManager();
                    roleManager.AssignKingRole(guild);
                }

                game = null;
                return "Your number is Guud";
            }
        }
    }
}
