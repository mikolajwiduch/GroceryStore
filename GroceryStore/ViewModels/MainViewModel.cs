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
            set { _currentView = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            // Register to listen for navigation messages
            Messenger.Default.Register<NavigateToProductsMessage>(this, OnNavigateToProductsMessage);
        }

        private void OnNavigateToProductsMessage(NavigateToProductsMessage message)
        {
            // Navigate to Products ViewModel
            CurrentView = new ProductsViewModel();
        }
    }
}
