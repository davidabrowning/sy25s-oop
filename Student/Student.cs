using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        private static int maxStudentId = 0;
        public int StudentId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Course CurrentCourse { get; set; }
        public Student(string firstName, string lastName, DateOnly dateOfBirth) : this(firstName, lastName, dateOfBirth, "None")
        {
        }

        public Student(string firstName, string lastName, DateOnly dateOfBirth, string courseName)
        {
            StudentId = ++maxStudentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Course.TryParse(courseName, out Course currentCourse);
            CurrentCourse = currentCourse;
        }
        public int Age()
        {
            DateTime today = DateTime.Today;
            DateTime dob = new DateTime(DateOfBirth, new TimeOnly());
            int age = today.Year - dob.Year - 1;

            // Kolla om studenten har fyllt år och isåfall lägg till ett år
            if (dob.Month < today.Month || dob.Month == today.Month && dob.Day <= today.Day)
            {
                age++;
            }

            return age;
        }
        public string Email()
        {
            return $"{FirstName.ToLower()}.{LastName.ToLower()}@studerande.yh.se";
        }
        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {FirstName} {LastName}, Email: {Email()}, DOB: {DateOfBirth}, Age: {Age()}, Course: {CurrentCourse}";
        }
    }
}
