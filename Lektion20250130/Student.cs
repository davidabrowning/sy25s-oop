using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion20250130
{
    public class Student
    {
        public string FirstName { get; set; } = "Unknown";
        public string LastName { get; set; } = "Unknown";
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return $"Student: {FirstName} {LastName}";
        }
    }
}
