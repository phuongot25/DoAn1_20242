using System.ComponentModel;
using System.Windows.Input;
using RestaurantManagement.Commands;
using RestaurantManagement.Views;

namespace RestaurantManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _mainContent;
        public object MainContent
        {
            get => _mainContent;
            set
            {
                _mainContent = value;
                OnPropertyChanged(nameof(MainContent));
            }
        }

        // Các Command để chuyển giao diện
        public ICommand ViewCustomerCommand { get; }
        public ICommand ViewStaffCommand { get; }
        public ICommand ViewTableCommand { get; }
        public ICommand ViewMenuCommand { get; }
        public ICommand ViewOrderAndPaymentCommand { get; }
        public ICommand ViewPromotionCommand { get; }
        public ICommand ViewStatisticsCommand { get; }
        public ICommand ViewFeedbackCommand { get; }

        public MainViewModel()
        {
            // Gán các command
            ViewCustomerCommand = new RelayCommand(_ => MainContent = new CustomerView());
            ViewStaffCommand = new RelayCommand(_ => MainContent = new StaffView());
            ViewTableCommand = new RelayCommand(_ => MainContent = new TableView());
            ViewMenuCommand = new RelayCommand(_ => MainContent = new MenuView());
            ViewOrderAndPaymentCommand = new RelayCommand(_ => MainContent = new OrderView());
            ViewPromotionCommand = new RelayCommand(_ => MainContent = new PromotionView());
            ViewStatisticsCommand = new RelayCommand(_ => MainContent = new RevenueView());
            ViewFeedbackCommand = new RelayCommand(_ => MainContent = new FeedbackView());

          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
