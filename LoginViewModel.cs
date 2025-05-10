using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using doan1;
using Microsoft.Win32;
using RestaurantManagement.Commands;
using RestaurantManagement.Views;

namespace RestaurantManagement.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SelectedRole { get; set; } = "Khách hàng";
        public string LoginMessage { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
        public ObservableCollection<string> Roles { get; set; } =
    new ObservableCollection<string> { "Khách hàng", "Nhân viên" };

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            NavigateRegisterCommand = new RelayCommand(NavigateToRegister);
        }

        private void Login(object obj)
        {
            if (SelectedRole == "Nhân viên")
            {
                if (Username == "NV01" && Password == "admin" )
                {
                    LoginMessage = "Đăng nhập quản lý thành công!";
                    NavigateToMainView("QuanLy");
                }
                else if (IsValidEmployee(Username, Password))
                {
                    LoginMessage = "Đăng nhập nhân viên thành công!";
                    NavigateToMainView("NhanVien");
                }
                else
                {
                    LoginMessage = "Sai tài khoản hoặc mật khẩu nhân viên!";
                }
            }
            else
            {
                if (IsValidCustomer(Username, Password))
                {
                    LoginMessage = "Đăng nhập khách hàng thành công!";
                    NavigateToMainView("KhachHang");
                }
                else
                {
                    LoginMessage = "Sai tài khoản hoặc mật khẩu khách hàng!";
                }
            }

            OnPropertyChanged(nameof(LoginMessage));
        }

        private void NavigateToRegister(object obj)
        {
            App.Current.MainWindow.Content = new RegisterView();
        }

        private void NavigateToMainView(string role)
        {
            App.Current.MainWindow.Content = new MainView();
            // Có thể truyền role vào MainViewModel nếu muốn phân quyền
        }

        private bool IsValidEmployee(string username, string password)
        {
            // TODO: Sau này kiểm tra bằng truy vấn từ SQL
            return username.StartsWith("NV") && password == "123";
        }

        private bool IsValidCustomer(string username, string password)
        {
            // TODO: Sau này kiểm tra bằng truy vấn từ SQL
            return username.StartsWith("KH") && password == "123";
        }

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
