using System.Collections.Generic;
using System.IO;

namespace GroceryStore.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public static List<Product> LoadProducts(string filePath)
        {
            var products = new List<Product>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                products.Add(new Product { Name = values[0], Price = decimal.Parse(values[1]), Category = values[2], Quantity = int.Parse(values[3]) });
            }

            return products;
        }
    }
}