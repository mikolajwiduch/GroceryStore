using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using GroceryStore.Models;

namespace GroceryStore.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Product> Cart { get; }

        public ICommand AddToCartCommand { get; }

        public ProductsViewModel(ObservableCollection<Product> cart)
        {
            Cart = cart ?? new ObservableCollection<Product>();
            Products = LoadProducts("Data/products.csv");
            AddToCartCommand = new RelayCommand(AddToCart);
        }

        private ObservableCollection<Product> LoadProducts(string filePath)
        {
            var products = new ObservableCollection<Product>();
            var lines = File.ReadAllLines(filePath).Skip(1); // Skip header

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    products.Add(new Product(parts[0], float.Parse(parts[1]), parts[2], int.Parse(parts[3])));
                }
            }

            return products;
        }

        private void AddToCart(object parameter)
        {
            if (parameter is Product product)
            {
                var existingProduct = Cart.FirstOrDefault(p => p.Name == product.Name);
                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    Cart.Add(new Product(product.Name, product.Price, product.Category, 1));
                }

                OnPropertyChanged(nameof(Cart));
            }
        }
    }
}
