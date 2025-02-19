using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    internal static class StudentHelper
    {
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 30; i++)
            {
                students.Add(new Student(
                    PersonHelper.GetFirstName(), 
                    PersonHelper.GetLastName(), 
                    PersonHelper.GetAge(),
                    GetCourse()));
            }
            return students;
        }
        public static string GetCourse()
        {
            List<string> courses = new List<string>();
            courses.Add("Fysik");
            courses.Add("Matematik");
            courses.Add("Engelska");
            courses.Add("Svenska");
            courses.Add("Spanska");
            courses.Add("Kemi");
            courses.Add("Programmering I");
            courses.Add("Programmering II");
            return StringHelper.ChooseOne(courses);
        }
    }
}
