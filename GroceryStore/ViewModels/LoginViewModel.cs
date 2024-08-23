using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login()
        {
            var users = User.LoadUsers("Data/users.csv");
            return User.Authenticate(Username, Password, users);
        }
    }

}
