using System.Collections.ObjectModel;
using System.Windows.Controls;
using GroceryStore.Models;
using GroceryStore.ViewModels;

namespace GroceryStore.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView(ObservableCollection<Product> cart)
        {
            InitializeComponent();
            DataContext = new OrderViewModel(cart);
        }
    }
}