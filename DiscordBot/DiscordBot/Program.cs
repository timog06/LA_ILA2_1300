using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Net;
using Discord.API;
using System.IO;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        private static CommandProcessor commandProcessor = new CommandProcessor();
        private SocketGuild _guild; // Store the guild once it becomes available

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

            // Attach the Ready and GuildAvailable event handlers
            _client.Ready += () =>
            {
                _guild = _client.GetGuild(1142008732402851870);
                InitializeRoleManager();
                return Task.CompletedTask;
            };

            _client.GuildAvailable += (guild) =>
            {
                if (guild.Id == 1142008732402851870)
                {
                    _guild = guild;
                    InitializeRoleManager();
                }
                return Task.CompletedTask;
            };

            var token = File.ReadAllText("Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private void InitializeRoleManager()
        {
            if (_guild != null)
            {
                RoleManager roleManager = new RoleManager();
            }
            else
            {
                Console.WriteLine("Guild is not yet available!");
            }
        }

        private Task ClientOnMessageReceived(SocketMessage arg)
        {
            if (arg.Content.StartsWith("§"))
            {
                commandProcessor.Choosing(arg, _guild);
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
