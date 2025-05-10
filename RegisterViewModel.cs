using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using doan1;
using RestaurantManagement.Commands;
using RestaurantManagement.Views;

namespace RestaurantManagement.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RegisterMessage { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
            NavigateLoginCommand = new RelayCommand(NavigateToLogin);
        }

        private void Register(object obj)
        {
            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(Phone) ||
                string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                RegisterMessage = "Vui lòng nhập đầy đủ thông tin!";
                OnPropertyChanged(nameof(RegisterMessage));
                return;
            }

            if (Password != ConfirmPassword)
            {
                RegisterMessage = "Mật khẩu không khớp!";
                OnPropertyChanged(nameof(RegisterMessage));
                return;
            }

          
            RegisterMessage = "Đăng ký thành công!";
            App.Current.MainWindow.Content = new LoginView();
        }

        private void NavigateToLogin(object obj)
        {
            App.Current.MainWindow.Content = new LoginView();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
