using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop_01_3990.Model
{
    public class Student
    {
        
        public string StudentID { get;  set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public string DateOfBirthDMY { get; set; }
        public double GPA { get; set; }

        
        public string Department { get; set; }  

        public String ImagePath
        {
            get { return $"/Images/{Image}"; }
        }

        public int Semester { get; set; }
   
  
        public Student(string studentID, int age, string firstName, string lastName, string gender, double gpa, int semester, BitmapImage image, string dateOfBirthDMY, string department)
        {
            DateOfBirthDMY = dateOfBirthDMY;
            StudentID = studentID;
            Age = age;
            Gender = gender;
            Semester = semester;
            GPA = gpa;
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            Department = department;
          
        }
   


        public Student(string v)
        {
        }

        public Student()
        {
        }
    }
}
