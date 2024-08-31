using System.Collections.ObjectModel;
using System.Windows.Input;
using GroceryStore.Models;

namespace GroceryStore.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Cart { get; }
        public float TotalPrice => Cart.Sum(p => p.Price * p.Quantity);

        public ICommand FinalizeOrderCommand { get; }

        public OrderViewModel(ObservableCollection<Product> cart)
        {
            Cart = cart;
            FinalizeOrderCommand = new RelayCommand(FinalizeOrder);
        }

        private void FinalizeOrder(object parameter)
        {
            // Logika finalizacji zamówienia (np. zapis do pliku lub bazy danych)
        }
    }
}
