using System.Windows;
using System.Windows.Controls;
using GroceryStore.ViewModels;

namespace GroceryStore.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (DataContext is LoginViewModel loginViewModel)
            {
                loginViewModel.Password = passwordBox.Password;
            }
        }
    }
}
