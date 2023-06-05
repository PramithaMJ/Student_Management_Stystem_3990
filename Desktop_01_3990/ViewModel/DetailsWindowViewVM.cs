using CommunityToolkit.Mvvm.ComponentModel;
using Desktop_01_3990.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop_01_3990.ViewModel
{
    public partial class DetailsWindowViewVM : ObservableObject

    {
        public string StudentID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BitmapImage Image { get; set; }
        public string DateOfBirthDMY { get; set; }
        public double GPA { get; set; }
        public string Department { get; set; }
        public int Semester { get; set; }
        public string ImagePath { get; set; }

        public DetailsWindowViewVM()
        {
            StudentID = StudentID;
            Age = Age;
            Gender = Gender;
            FirstName = FirstName;
            LastName = LastName;
            Image = Image;
            DateOfBirthDMY =DateOfBirthDMY;
            GPA = GPA;
            Department = Department;
            Semester = Semester;
            ImagePath = ImagePath;
        }

    }
}
