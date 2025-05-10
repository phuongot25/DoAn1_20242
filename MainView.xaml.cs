using System.Windows.Controls;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}

