using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningArv
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; private set; }
        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public abstract void MakeNoise();
        public override string ToString()
        {
            return $"{Name}, {Age} år gammal";
        }
    }
}
