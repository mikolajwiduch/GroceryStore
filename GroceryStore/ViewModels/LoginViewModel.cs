using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GroceryStore.Messages;

namespace GroceryStore.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private void ExecuteLogin()
        {
            if (IsValidUser(Username, Password))
            {
                Messenger.Default.Send(new NavigateToProductsMessage());
            }
            else
            {
                ErrorMessage = "Niepoprawna nazwa użytkownika lub hasło.";
                MessageBox.Show(ErrorMessage, "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Logika sprawdzania poprawności użytkownika
            return username == "user" && password == "password";
        }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
