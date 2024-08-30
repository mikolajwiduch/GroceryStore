using GroceryStore.Models;
using GroceryStore.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class OrderViewModel : BaseViewModel
{
    public ObservableCollection<Product> Cart { get; }

    public ICommand FinalizeOrderCommand { get; }

    public OrderViewModel(ObservableCollection<Product> cart)
    {
        Cart = cart;
        FinalizeOrderCommand = new RelayCommand(FinalizeOrder);
    }

    private void FinalizeOrder(object parameter)
    {
        // Implement logic to finalize the order
    }
}