using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningArv
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }
        public override void MakeNoise()
        {
            Console.WriteLine($"{base.ToString()}, säger mjau!");
        }
    }
}
