using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Desktop_01_3990.ViewModel;
using Desktop_01_3990.View;
using System.ComponentModel;
using Desktop_01_3990.Model;

namespace Desktop_01_3990
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();    
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 3)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var row = e.Source as DataGridRow;

                DetailsWindowView detailsWindow = new DetailsWindowView(row.Item);
                detailsWindow.Owner = this;

                detailsWindow.Show();


            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text;
            ICollectionView view = CollectionViewSource.GetDefaultView(StudentsDatagrid.ItemsSource);

            TextBlock searchPlaceholderTextBlock = (TextBlock)FindName("searchPlaceholderTextBlock");

            if (!string.IsNullOrEmpty(searchText))
            {
                view.Filter = item =>
                {
                    Student student2 = item as Student;
                    return (student2 != null) &&
                           (student2.StudentID.Contains(searchText) ||
                            student2.FirstName.Contains(searchText) ||
                            student2.LastName.Contains(searchText) ||
                            student2.Age.ToString().Contains(searchText) ||
                            student2.DateOfBirthDMY.ToString().Contains(searchText) ||
                            student2.Department.ToString().Contains(searchText) ||
                            student2.GPA.ToString().Contains(searchText));
                };

                searchPlaceholderTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                view.Filter = null;
                searchPlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }


        private void Button_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Resize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help_featuresView helpWindow = new Help_featuresView();
            helpWindow.Show();
        }
    }

}
