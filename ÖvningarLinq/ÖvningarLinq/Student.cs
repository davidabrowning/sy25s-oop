using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    public class Student : Person
    {
        public string Course { get; set; }
        public Student(string firstName, string lastName, int age, string course) : base (firstName, lastName, age)
        {
            Course = course;
        }
        public override string ToString()
        {
            return $"{base.ToString()} - {Course}";
        }
    }
}
