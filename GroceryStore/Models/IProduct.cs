using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public interface IProduct
    {
        string Name { get; }
        float Price { get; }
        string Category { get; }
        int Quantity { get; set; }
    }
}
