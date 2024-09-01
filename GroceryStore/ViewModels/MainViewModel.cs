using GroceryStore.Models;
using GroceryStore.ViewModels;
using GroceryStore.Views;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace GroceryStore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ICommand ViewCartCommand { get; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadProductsFromFile("Data/products.csv");
            ViewCartCommand = new RelayCommand(o => OpenCart());
        }

        private void LoadProductsFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(',').Select(part => part.Trim()).ToArray();
                if (parts.Length != 4) continue;

                if (float.TryParse(parts[1], out var price) && int.TryParse(parts[3], out var quantity))
                {
                    var product = new Product(parts[0], // Name
                                              price, // Price
                                              parts[2], // Description
                                              quantity); // Quantity
                    Products.Add(product);
                }
                else
                {
                    // Zapisz lub wyświetl błąd, jeśli dane są niepoprawne
                    Console.WriteLine($"Błąd formatowania danych: {line}");
                }
            }
        }


        private void OpenCart()
        {
            var cartView = new CartView(this);
            cartView.Show();
        }
    }
}