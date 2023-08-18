
using Discord;
using Discord.WebSocket;

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

            // Enter your token here, or better still, read it from file
            var token = "MTEwMDI5ODg0MTc3NDg5OTIxMQ.GJfFDy.y9a6do1lmoCL5m4l0KcXWXhWlMxytkrUvgjo8M";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}