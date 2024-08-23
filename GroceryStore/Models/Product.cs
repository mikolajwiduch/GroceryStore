using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        // Załaduj produkty z pliku CSV
        public static IEnumerable<Product> LoadProducts(string filePath)
        {
            var products = new List<Product>();

            foreach (var line in File.ReadLines(filePath).Skip(1)) // Pomijamy nagłówek
            {
                var columns = line.Split(',');

                if (columns.Length == 2 && decimal.TryParse(columns[1], out var price))
                {
                    products.Add(new Product
                    {
                        Name = columns[0],
                        Price = price
                    });
                }
            }

            return products;
        }
    }
}
