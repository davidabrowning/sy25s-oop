using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class Student
    {
        
        public string Name { get; set; }
        // public int Age { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public Student()
        {
            Name = "Unknown";
        }
        public Student(string name)
        {
            Name = name;
        }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Birthday()
        {
            Age++;
            Console.WriteLine($"Grattis på din {Age} födelsedag, {Name}");
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
