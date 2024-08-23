using System;
using System.Windows;
using System.Windows.Input;
using GroceryStore.Models;

namespace GroceryStore.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Order CurrentOrder { get; set; }

        public ICommand FinalizeOrderCommand => new RelayCommand(FinalizeOrder);

        public OrderViewModel()
        {
            CurrentOrder = new Order();
        }

        private void FinalizeOrder()
        {
            var orderNumber = $"#{DateTime.Now:dd-MM-yyyy}-{new Random().Next(0, 9999):D4}";
            MessageBox.Show($"Order confirmed! Your order number is {orderNumber}");
            CurrentOrder.FinalizeOrder();
        }
    }
}
