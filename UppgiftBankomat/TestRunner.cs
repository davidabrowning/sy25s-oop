using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // TestRunner. Entry point for unit testing. 
    // ========================================================================
    internal class TestRunner
    {
        // ============================== METHOD ==============================
        // RunAllTests. Calls each class's static test method to run the
        // class's unit tests.
        // ====================================================================
        internal void RunAllTests()
        {
            Console.WriteLine("Kör alla tester.");
            Bankomat.RunTests();
            Account.RunTests();
        }
    }
}
