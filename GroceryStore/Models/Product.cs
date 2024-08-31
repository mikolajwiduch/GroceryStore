using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.Models
{
    public class Product : IProduct
    {
        public string Name { get; internal set; }
        public float Price { get; internal set; }
        public string Category { get; internal set; }
        public int Quantity { get; set; }

        public Product(string name, float price, string category, int quantity)
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
        }
    }
}
