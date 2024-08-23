using System.Windows;
using GroceryStore.Views;

namespace GroceryStore
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = new LoginView();
            loginView.Show();
        }
    }
}
