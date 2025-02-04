using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class TestRunner
    {
        internal void RunAllTests()
        {
            Printer.PrintTitle ("Kör alla tester.");
            Bankomat.RunTests();
            Account.RunTests();
        }
    }
}
