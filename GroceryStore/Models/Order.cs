using System.Collections.Generic;

namespace GroceryStore.Models
{
    public class Order
    {
        public List<Product> Products { get; private set; }
        public float TotalPrice => Products.Sum(p => p.Price * p.Quantity);

        public Order()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void FinalizeOrder()
        {
            // Finalize the order, e.g., save to CSV or database
        }
    }
}