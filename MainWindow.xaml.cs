using System.Windows;
using RestaurantManagement.Views;

namespace RestaurantManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Giao diện đầu tiên là LoginView
            this.Content = new LoginView();
        }
    }
}

