using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInheritance
{
    public class Student : Person
    {
        public string Course { get; set; } = "";
        public Student() : base() { }
        public Student(string firstName, string lastName) : base(firstName, lastName) 
        {

        }

        public new string Salute()
        {
            return ($"Hi {FirstName} {LastName} member of course {Course}");
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
