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
            DataContext = new LoginViewModel(); // Przypisz ViewModel
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                var passwordBox = sender as PasswordBox;
                if (passwordBox != null)
                {
                    viewModel.Password = passwordBox.Password;
                }
            }
        }
    }
}
