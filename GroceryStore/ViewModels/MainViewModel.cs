using System.Windows.Input;
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
            NavigateToProductsCommand = new RelayCommand(ExecuteNavigateToProducts);
            NavigateToOrderCommand = new RelayCommand(ExecuteNavigateToOrder);

            // Set initial view
            CurrentView = new ProductView();
        }

        private void ExecuteNavigateToProducts(object parameter)
        {
            CurrentView = new ProductView();
        }

        private void ExecuteNavigateToOrder(object parameter)
        {
            CurrentView = new OrderView();
        }
    }
}
