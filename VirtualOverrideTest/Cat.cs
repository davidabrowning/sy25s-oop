using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOverrideTest
{
    public class Cat
    {
        public void Meow() { Console.WriteLine("Cat meow"); }
        public virtual void Purr() { Console.WriteLine("Cat purr"); }
    }
}
