using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static List<User> LoadUsers(string filePath)
        {
            var users = new List<User>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                users.Add(new User { Username = values[0], Password = values[1] });
            }

            return users;
        }

        public static bool Authenticate(string username, string password, List<User> users)
        {
            return users.Any(user => user.Username == username && user.Password == password);
        }
    }
}
