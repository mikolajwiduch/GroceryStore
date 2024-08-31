using GroceryStore.Models;
using GroceryStore.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

public class MainViewModel : BaseViewModel
{
    public ObservableCollection<IProduct> Products { get; set; }
    public ObservableCollection<IProduct> Cart { get; set; }
    public ICommand AddToCartCommand { get; }

    public MainViewModel()
    {
        Products = new ObservableCollection<IProduct>();
        Cart = new ObservableCollection<IProduct>();
        LoadProducts();
        AddToCartCommand = new RelayCommand(o => AddToCart((IProduct)o));
    }

    private void LoadProducts()
    {
        string[] lines = File.ReadAllLines("Data/products.csv");
        foreach (var line in lines.Skip(1))
        {
            var values = line.Split(',');
            Products.Add(new Product(values[0], decimal.Parse(values[1]), values[2], int.Parse(values[3])));
        }
    }

    private void AddToCart(IProduct product)
    {
        var productInCart = Cart.FirstOrDefault(p => p.Name == product.Name);
        if (productInCart != null)
        {
            productInCart.Quantity++;
        }
        else
        {
            Cart.Add(new Product(product.Name, product.Price, product.Category, 1));
        }
    }
}
