using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;

public class RoleManager
{
    private readonly SocketGuild _guild;

    public RoleManager(SocketGuild guild)
    {
        _guild = guild ?? throw new ArgumentNullException(nameof(guild));
    }

    public async Task<bool> AssignRoleToUserAsync(ulong userId, string roleName)
    {
        var user = _guild.GetUser(userId);
        var role = _guild.Roles.FirstOrDefault(x => x.Name == roleName);

        if (user != null && role != null)
        {
            if (!user.Roles.Contains(role))
            {
                await user.AddRoleAsync(role);
                return true;
            }
        }
        return false;
    }

    public async Task<bool> RemoveRoleFromUserAsync(ulong userId, string roleName)
    {
        var user = _guild.GetUser(userId);
        var role = _guild.Roles.FirstOrDefault(x => x.Name == roleName);

        if (user != null && role != null)
        {
            if (user.Roles.Contains(role))
            {
                await user.RemoveRoleAsync(role);
                return true;
            }
        }
        return false;
    }
}
