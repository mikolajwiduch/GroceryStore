using GroceryStore.Models;
using GroceryStore.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class ProductsViewModel : BaseViewModel
{
    public ObservableCollection<Product> Products { get; }
    public ObservableCollection<Product> Cart { get; }

    public ICommand AddToCartCommand { get; }

    public ProductsViewModel(ObservableCollection<Product> cart)
    {
        Cart = cart;
        Products = new ObservableCollection<Product>(Product.LoadProducts("Data/products.csv"));
        AddToCartCommand = new RelayCommand(AddToCart);
    }

    private void AddToCart(object parameter)
    {
        if (parameter is Product product)
        {
            Cart.Add(product);
        }
    }
}