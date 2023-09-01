using Discord.WebSocket;
using Discord;
using static filegrabber;

namespace DiscordBot
{
    class RoleManager
    {
        private SocketGuild _guild = null;

        public RoleManager(SocketGuild guild)
        {
            _guild = guild;
        }

        public async Task AssignKingRole()
        {
            Dictionary<string, User> users = UserData.LoadUsers();
            User topUser = users.Values.OrderByDescending(userpoints => userpoints.points).FirstOrDefault();

            if (topUser != null)
            {
                SocketGuildUser guildUser = _guild.GetUser(ulong.Parse(topUser.id));
                if (guildUser != null)
                {
                    IRole kingRole = _guild.Roles.FirstOrDefault(r => r.Name == "KOTNG");
                    if (kingRole == null)
                    {
                        kingRole = await _guild.CreateRoleAsync("KOTNG", GuildPermissions.None, null, false, false, null);
                    }
                    await guildUser.AddRoleAsync(kingRole);
                }
            }
        }
    }
}
