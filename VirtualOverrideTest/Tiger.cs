using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOverrideTest
{
    public class Tiger : Cat
    {
        public new void Meow() { Console.WriteLine("Tiger meow"); }
        public override void Purr() { Console.WriteLine("Tiger purr"); }
    }
}
