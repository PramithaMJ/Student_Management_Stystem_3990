using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Desktop_01_3990.ViewModel
{
    public partial class LogInWindowVM :ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;



       // public ICommand LoginCommand { get; }

        public LogInWindowVM()
        {
           // LoginCommand = new RelayCommand(Login);
        }
        [RelayCommand]
        private void Login()
        {
            // Perform login logic here
            // You can access the username and password via the properties Username and Password
            // For example:
            if (Username == "admin" && Password == "1234")
            {
                MainWindow mainLg = new MainWindow();
                CloseCurrentWindow();
                mainLg.Show();
                
                // Login successful
                // Navigate to the main application window or perform any desired actions
            }
            else
            {
                // Login failed
                // Display an error message or perform any desired actions
                MessageBox.Show("Incorrect User Name or Password!!!");
            }
          
        }
        public void CloseCurrentWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
    }
}
