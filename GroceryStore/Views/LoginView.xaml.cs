using GroceryStore.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace GroceryStore.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(); // Przypisz ViewModel
        }

        // Metoda obsługi zmiany hasła w PasswordBox
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
