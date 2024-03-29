﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Desktop_01_3990.Model;
using System.Collections.ObjectModel;
using System.IO.Packaging;

namespace Desktop_01_3990.ViewModel
{
    public partial class AddEditStudentVM : ObservableObject

    {
        [ObservableProperty]
        public string studentID;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        public string firstname;

        [ObservableProperty]
        public int semester;

        public ObservableCollection<int> Semesters { get; } = 
            new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        public string lastname;

        [ObservableProperty]
        public int age;

        //[ObservableProperty]
        //public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string gender;

        public ObservableCollection<string> GenderOptions { get; } = 
            new ObservableCollection<string> { "Male", "Female" };
       

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public DateOnly dateOfBirthDMY;

        [ObservableProperty]
        public string department;
        public ObservableCollection<string> Departments { get; } = 
            new ObservableCollection<string> { "Electrical Engineering", "Computer Engineering", "Mechanical Engineering","Civil and Environment Engineering" };


        [ObservableProperty]
        private string selectedModule;

        [ObservableProperty]
        private ObservableCollection<string> modules;

        public Student Student1 { get; private set; }
        public Action CloseAction { get; internal set; }


        public string FullName
        {
            get{
                return  $"{Firstname} {Lastname}"; 
            }
        }
       
        private void PopulateModules()
        {
            // Clear existing modules
            modules.Clear();

            // Add modules based on semester and department
            if (semester == 3 && department == "Electrical Engineering")
            {
                modules.Add("Module 1");
                modules.Add("Module 2");
                modules.Add("Module 3");
                
            }

            else if (semester == 4 && department == "Computer Engineering")
            {
                modules.Add("Module 4");
                modules.Add("Module 5");
                modules.Add("Module 6");
                
            }
           
            // Clear the selected module
            SelectedModule = null;
        }

        public AddEditStudentVM(Student u)
        {
            Student1 = u;
            // Assigning values from the  student object
  
            studentID = Student1.StudentID;
            firstname = Student1.FirstName;
            lastname = Student1.LastName;
            age = Student1.Age;
            gpa = Student1.GPA;
            gender = Student1.Gender ;
            semester = Student1.Semester; ;
            dateOfBirthDMY = Student1.DateOfBirthDMY;
           // dateofbirth = Student1.DateOfBirth;
            selectedImage = Student1.Image;
            department = Student1.Department;
        }

        public AddEditStudentVM()
        {
            modules = new ObservableCollection<string>();
            PopulateModules();
        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image successfully uploaded!", "Success");
            }
        }

        [RelayCommand]
        public void Save()
        {
            if (gpa < 0.0 || gpa > 4.0)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "GPA Error");
                return;
            }
            if (Student1 == null)
            {

                Student1 = new Student()
                {
                    StudentID = studentID,
                    FirstName = firstname,
                    LastName = lastname,
                    Semester = semester,
                    Age = age,
                    Gender = gender,
                  //  DateOfBirth = dateofbirth,
                    Image = selectedImage,
                    GPA = gpa,
                   DateOfBirthDMY = dateOfBirthDMY,
                    Department = department
                };
            }
            else
            {
                Student1.Semester = semester;
                Student1.FirstName = firstname;
                Student1.LastName = lastname;
                Student1.Age = age;
                Student1.GPA = gpa;
               // Student1.DateOfBirth = dateofbirth;
                Student1.Gender = gender;
                Student1.Image = selectedImage;

                Student1.DateOfBirthDMY = dateOfBirthDMY;
                Student1.Department = department;
            }
            if (Student1.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
