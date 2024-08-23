using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Order
    {
        public List<Product> Products { get; private set; }
        public decimal TotalPrice => Products.Sum(p => p.Price * p.Quantity);

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
            // Logika finalizacji zamówienia
        }
    }

}
