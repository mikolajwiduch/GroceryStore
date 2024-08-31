using GroceryStore.Models;
using GroceryStore;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace GroceryStore.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<IProduct> Cart { get; set; }
        public float TotalPrice => Cart.Sum(p => p.Price * p.Quantity);
        public ICommand FinalizeOrderCommand { get; }

        public CartViewModel()
        {
            Cart = new ObservableCollection<IProduct>();
            FinalizeOrderCommand = new RelayCommand(param => FinalizeOrder());
        }

        public CartViewModel(ObservableCollection<IProduct> cart) : this()
        {
            Cart = cart;
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

            // Show a confirmation message
            System.Windows.MessageBox.Show($"Order {orderId} has been finalized!", "Order Finalized", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

            // Clear the cart
            Cart.Clear();
        }
    }
}