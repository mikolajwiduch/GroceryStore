using System.Collections.ObjectModel;
using GroceryStore.Models;

namespace GroceryStore.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>(Product.LoadProducts("Data/products.csv"));
        }
    }
}
