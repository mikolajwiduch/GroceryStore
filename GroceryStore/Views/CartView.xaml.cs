using GroceryStore.ViewModels;
using System.Windows;

namespace GroceryStore.Views
{
    public partial class CartView : Window
    {
        public CartView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = new CartViewModel(mainViewModel);
        }
    }
}