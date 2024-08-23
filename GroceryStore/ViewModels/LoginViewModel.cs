using System.Windows;
using System.Windows.Input;
using GroceryStore.Models;
using GroceryStore.Views;

namespace GroceryStore.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        private void Login()
        {
            var users = User.LoadUsers("Data/users.csv");
            if (User.Authenticate(Username, Password, users))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.Windows[0].Close();  // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
