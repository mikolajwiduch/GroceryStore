using GroceryStore.Models;
using GroceryStore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

public class CartViewModel : BaseViewModel
{
    public ObservableCollection<IProduct> Cart { get; set; }
    public decimal TotalPrice => Cart.Sum(p => p.Price * p.Quantity);
    public ICommand FinalizeOrderCommand { get; }

    public CartViewModel(ObservableCollection<IProduct> cart)
    {
        Cart = cart;
        FinalizeOrderCommand = new RelayCommand(o => FinalizeOrder());
    }

    private void FinalizeOrder()
    {
        string orderId = $"#{DateTime.Now:ddMMyy}-{new Random().Next(1, 100):D2}";
        string orderFilePath = "Data/orders.csv";
        using (var writer = new StreamWriter(orderFilePath, true))
        {
            foreach (var product in Cart)
            {
                writer.WriteLine($"{orderId},{product.Name},{product.Quantity},{product.Price * product.Quantity}");
            }
        }

        // Update Product Quantities (implement this logic)
        // ...

        // Show a confirmation message
        MessageBox.Show($"Order {orderId} has been finalized!", "Order Finalized", MessageBoxButton.OK, MessageBoxImage.Information);

        // Clear the cart
        Cart.Clear();
    }
}
