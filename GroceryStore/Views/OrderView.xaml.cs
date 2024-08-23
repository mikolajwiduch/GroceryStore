using System.Windows.Controls;

namespace GroceryStore.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            DataContext = new ViewModels.OrderViewModel();
        }
    }
}
