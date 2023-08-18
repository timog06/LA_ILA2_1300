
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Net;
using Discord.API;

namespace DiscordBot
{
    class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig()
            { 
                // Other config options can be presented here.
                GatewayIntents =
                GatewayIntents.AllUnprivileged |
                GatewayIntents.MessageContent
            };
            _client = new DiscordSocketClient(config);

            _client.Log += Log;
            _client.MessageReceived += ClientOnMessageReceived;

            // Enter your token here, or better still, read it from file

            var token = File.ReadAllText("Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private static Task ClientOnMessageReceived(SocketMessage arg)
        {

            if (arg.Content.StartsWith("§"))
            {
                //arg.Channel.SendMessageAsync($"User '{arg.Author.Username}' successfully ran helloworld!");
                string[] command = arg.Content.Split('§');

                switch (command[1])
                {
                    case "rnd":
                        Random rnd = new();
                        Randomnuberguesser game = new() { randomNumber = rnd.Next(1, 101)};
                        arg.Channel.SendMessageAsync($"Successfully Created random number, you can guess now:");
                        break;
                    case "g":
                        string[] guess = command[1].Split(' ');
                        if (Convert.ToInt32(guess[1]) > game.randomNumber)
                        {
                            arg.Channel.SendMessageAsync();
                        }
                        break;

                    case "highscorelist":

                        break;
                    case "highscore @username":

                        break;
                    case "help":

                        break;
                }
            }

            return Task.CompletedTask;
        }
        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
