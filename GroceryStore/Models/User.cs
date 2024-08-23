using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static List<User> LoadUsers(string filePath)
        {
            var users = new List<User>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var user = new User(values[0], values[1]);
                users.Add(user);
            }

            return users;
        }

        public static bool Authenticate(string username, string password, List<User> users)
        {
            return users.Any(user => user.Username == username && user.Password == password);
        }
    }

}
