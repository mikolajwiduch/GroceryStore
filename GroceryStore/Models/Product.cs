using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.Models
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        string Category { get; }
        int Quantity { get; set; }
    }


    public class Product : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, string category, int quantity)
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
        }
    }
}
