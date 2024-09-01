using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GroceryStore.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void OnQuantityPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void OnQuantityTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            int currentQuantity = int.Parse(textBox.Tag.ToString());
            int enteredQuantity;

            if (!int.TryParse(textBox.Text, out enteredQuantity) || enteredQuantity < 0)
            {
                textBox.Background = Brushes.Red;
            }
            else if (enteredQuantity > currentQuantity)
            {
                textBox.Background = Brushes.Orange;
                MessageBox.Show("There is not enough stock available.", "Invalid Quantity", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                textBox.Background = Brushes.White;
            }
        }
    }
}
