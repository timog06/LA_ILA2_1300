using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public class filegrabber
{

    public static class UserData
    {
        private static readonly string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "userpoints.json");

        public static Dictionary<string, User> LoadUsers()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Dictionary<string, User>>(json);
            }
            return new Dictionary<string, User>();
        }

        public static void SaveUser(User user)
        {
            var users = LoadUsers();
            users[user.id] = user;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(filePath, json);
        }
    }

    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }
        public int points { get; set; }
    }

}