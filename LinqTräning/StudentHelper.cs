using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTräning
{
    internal static class StudentHelper
    {
        public static List<Student> GetStudents()
        {
            var students = new List<Student>();
            students.Add(new Student("Erin", "E", "Sundsvall", 3));
            students.Add(new Student("Frank", "F", "Göteborg", 1));
            students.Add(new Student("Genny", "G", "Stockholm", 2));
            students.Add(new Student("Harriet", "H", "Stockholm", 1));
            students.Add(new Student("Adam", "A", "Umeå", 1));
            students.Add(new Student("Ben", "B", "Stockholm", 2));
            students.Add(new Student("Charlie", "C", "Stockholm", 1));
            students.Add(new Student("Denise", "D", "Stockholm", 2));
            students.Add(new Student("Ingrid", "I", "Göteborg", 3));
            students.Add(new Student("Johan", "J", "Stockholm", 3));
            return students;
        }
    }
}
