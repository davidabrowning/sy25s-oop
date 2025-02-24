using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemläxaGenerics
{
    static internal class FredriksHelper
    {
        public static void PrintParameters<T>(T parameter1, T parameter2)
        {
            Console.WriteLine($"Parameter1 : {parameter1} | Parameter2 : {parameter2}");
        }
    }
}
