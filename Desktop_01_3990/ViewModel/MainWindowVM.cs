using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Desktop_01_3990.Model;
using Desktop_01_3990.View;

namespace Desktop_01_3990.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messsage()
        {

            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddEditStudentVM();
            vm.title = "ADD STUDENT ";
            AddStudentView window = new AddStudentView(vm);
            window.ShowDialog();

            if (vm.Student1 != null && vm.Student1.FirstName != null)
            {
                students.Add(vm.Student1);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly!!!.", "DELETED \a ");
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");
            }
        }

        [RelayCommand]
        public void EditStudentCommand()
        {
            if (selectedStudent != null)
            {
                var vm = new AddEditStudentVM(selectedStudent);
               
                vm.title = "EDIT STUDENT";
                var window = new AddStudentView(vm);
               
                window.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.Student1);
            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student("EG/2020/3895", 12, "Amali", "Rathnayaka", "Female", 2.45, 3, image1, new DateOnly(1999, 11, 12), "Elecrical"));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student("EG/2021/3892", 12, "Dinithi", "Dhanushika", "FeMale", 3.45, 2, image2, new DateOnly(2000, 8, 25), "Computer"));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            students.Add(new Student("EG/2018/2892", 12, "Kamal", "Ruwan", "Male", 2.48, 8, image3, new DateOnly(1998, 5, 21), "Mechanical"));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            students.Add(new Student("EG/2021/7845", 12, "Kasuni", "Kalhara", "FeMale", 3.2, 1, image4, new DateOnly(1999, 2, 24), "Civil and Environment"));
        }

        [RelayCommand]
        public void Logout()
        {
            LogInWindowView mainLg = new LogInWindowView();
            mainLg.Show();
            CloseCurrentWindow();
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
