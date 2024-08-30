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
            Cart = cart;
            Products = LoadProducts("Data/products.csv");
            AddToCartCommand = new RelayCommand(AddToCart);
        }

        private ObservableCollection<Product> LoadProducts(string filePath)
        {
            var products = new ObservableCollection<Product>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                products.Add(new Product
                {
                    Name = parts[0],
                    Price = decimal.Parse(parts[1]),
                    Category = parts[2], // Kategoria produktu
                    Quantity = 1 // Domyślnie ustawiamy ilość na 1, aby użytkownik mógł zmieniać
                });
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
                    // Jeśli produkt już jest w koszyku, zwiększamy jego ilość
                    existingProduct.Quantity++;
                }
                else
                {
                    // Jeśli produkt nie jest w koszyku, dodajemy go
                    Cart.Add(new Product
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Category = product.Category,
                        Quantity = 1 // Domyślnie dodajemy 1 sztukę
                    });
                }

                // Powiadamiamy o zmianie
                OnPropertyChanged(nameof(Cart));
            }
        }
    }
}
