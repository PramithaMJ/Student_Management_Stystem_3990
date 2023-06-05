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

            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error!!!");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var AddVm = new AddEditStudentVM();
            AddVm.title = "ADD STUDENT ";
            AddStudentView window = new AddStudentView(AddVm);
            window.ShowDialog();

            if (AddVm.Student1 != null && AddVm.Student1.FirstName != null)
            {
                students.Add(AddVm.Student1);
            }
        }


        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly!!!.", "DELETED! \a ");

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
                var AEvm = new AddEditStudentVM(selectedStudent);

                AEvm.title = "EDIT STUDENT";
                var window = new AddStudentView(AEvm);

                window.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, AEvm.Student1);

            }
            else
            {
                MessageBox.Show("Please Select Student", "Warning!");
            }
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student("EG/2020/3990", 12, "Amali", "Rathnayaka", "Female", 2.45, 3, image1, "1999/05/21", "Elecrical"));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student("EG/2021/3985", 12, "Pramitha", "Jaysooriya", "Male", 3.25, 2, image2, "2000/01/31", "Computer"));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            students.Add(new Student("EG/2018/2892", 12, "Kamal", "Ruwan", "Male", 2.48, 8, image3, "1998/05/21", "Mechanical"));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            students.Add(new Student("EG/2021/7845", 12, "Kasuni", "Kalhara", "Female", 3.2, 1, image4, "1999/02/24", "Civil and Environment"));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            students.Add(new Student("EG/2020/3818", 12, "Samal", "Rasindu", "Male", 3.8, 1, image5, "1998/5/12", "Mechanical"));
            BitmapImage image6 = new BitmapImage(new Uri("/Model/Images/6.png", UriKind.Relative));
            students.Add(new Student("EG/2019/3201", 12, "Nimali", "Rajmanya", "Female", 2.8, 1, image6, "2001/03/22", "Computer"));
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
