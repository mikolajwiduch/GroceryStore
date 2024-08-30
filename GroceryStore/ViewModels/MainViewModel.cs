using System.Collections.ObjectModel;
using System.Windows.Input;
using GroceryStore.Models;
using GroceryStore.Views;

namespace GroceryStore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToProductsCommand { get; }
        public ICommand NavigateToOrderCommand { get; }

        public MainViewModel()
        {
            Cart = new ObservableCollection<Product>();

            NavigateToProductsCommand = new RelayCommand(ExecuteNavigateToProducts);
            NavigateToOrderCommand = new RelayCommand(ExecuteNavigateToOrder);

            // Set initial view
            ExecuteNavigateToProducts(null);
        }

        private void ExecuteNavigateToProducts(object parameter)
        {
            var productsViewModel = new ProductsViewModel(Cart);
            CurrentView = new ProductView() { DataContext = productsViewModel };
        }

        private void ExecuteNavigateToOrder(object parameter)
        {
            var orderViewModel = new OrderViewModel(Cart);
            CurrentView = new OrderView() { DataContext = orderViewModel };
        }

    }
}
