using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        public Order CurrentOrder { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>(Product.LoadProducts("Data/products.csv"));
            CurrentOrder = new Order();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
