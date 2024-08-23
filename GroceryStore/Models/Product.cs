using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public static List<Product> LoadProducts(string filePath)
        {
            var products = new List<Product>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var product = new Product(values[0], int.Parse(values[1]), decimal.Parse(values[2]));
                products.Add(product);
            }

            return products;
        }
    }

}
