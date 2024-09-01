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
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Plik użytkowników nie został znaleziony.", fullPath);
            }

            var lines = File.ReadAllLines(fullPath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 2)
                {
                    users.Add(new User { Username = values[0], Password = values[1] });
                }
            }

            return users;
        }

        public static bool Authenticate(string username, string password, List<User> users)
        {
            return users.Any(user => user.Username == username && user.Password == password);
        }
    }
}
