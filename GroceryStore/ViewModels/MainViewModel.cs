using GalaSoft.MvvmLight.CommandWpf;
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

        // Komenda z parametrem
        public ICommand NavigateToViewCommand => new RelayCommand<object>(NavigateToView);

        private void NavigateToView(object viewModel)
        {
            if (viewModel is BaseViewModel vm)
            {
                CurrentView = vm;
            }
        }

        public MainViewModel()
        {
            CurrentView = new ProductsViewModel();  // Domyślnie produkty
        }
    }
}
