using GroceryStore.Models;
using GroceryStore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace GroceryStore.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public ObservableCollection<Product> Cart { get; }
        public float TotalPrice => Cart.Sum(p => p.Price * p.Quantity);
        public ICommand FinalizeOrderCommand { get; }
        public ICommand RemoveFromCartCommand { get; }

        public CartViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            Cart = new ObservableCollection<Product>();

            FinalizeOrderCommand = new RelayCommand(o => FinalizeOrder());
            RemoveFromCartCommand = new RelayCommand(o => RemoveFromCart(o));
        }

        private void RemoveFromCart(object parameter)
        {
            if (parameter is Product product)
            {
                Cart.Remove(product);
                OnPropertyChanged(nameof(TotalPrice));
            }
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
                    var productInStock = _mainViewModel.Products.FirstOrDefault(p => p.Name == product.Name);
                    if (productInStock != null)
                    {
                        productInStock.Quantity -= product.Quantity;
                    }
                }
            }

            MessageBox.Show($"Order {orderId} has been finalized!", "Order Finalized", MessageBoxButton.OK, MessageBoxImage.Information);
            Cart.Clear();
            OnPropertyChanged(nameof(Cart));
            OnPropertyChanged(nameof(TotalPrice));
        }
    }
}