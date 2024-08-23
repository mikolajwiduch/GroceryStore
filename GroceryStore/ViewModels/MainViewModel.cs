using System.Windows.Input;

namespace GroceryStore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand NavigateToProductsCommand => new RelayCommand(NavigateToProducts);
        public ICommand NavigateToOrderCommand => new RelayCommand(NavigateToOrder);

        private void NavigateToProducts()
        {
            CurrentView = new ProductsViewModel();
        }

        private void NavigateToOrder()
        {
            CurrentView = new OrderViewModel();
        }

        public MainViewModel()
        {
            CurrentView = new ProductsViewModel();  // Default to Products view
        }
    }
}
