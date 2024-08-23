using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GroceryStore.Messages;

namespace GroceryStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; RaisePropertyChanged(nameof(CurrentView)); }
        }

        public MainViewModel()
        {
            Messenger.Default.Register<NavigateToProductsMessage>(OnNavigateToProductsMessage);

            // Domyślnie wyświetl LoginViewModel
            CurrentView = new LoginViewModel();
        }

        private void OnNavigateToProductsMessage(NavigateToProductsMessage message)
        {
            // Zmiana widoku na ProductsViewModel
            CurrentView = new ProductsViewModel();
        }
    }
}
