
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

            if (arg.Content.StartsWith("!helloworld"))
            {
                arg.Channel.SendMessageAsync($"User '{arg.Author.Username}' successfully ran helloworld!");
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
