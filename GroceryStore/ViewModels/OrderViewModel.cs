using System.Windows.Input;

namespace GroceryStore.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public ICommand PlaceOrderCommand { get; private set; }

        public OrderViewModel()
        {
            PlaceOrderCommand = new RelayCommand(param => PlaceOrder());
        }

        private void PlaceOrder()
        {
            // Implementacja logiki zamówienia
        }
    }
}
