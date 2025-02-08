using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // TestHelper. Static class with static methods that support testing.
    // ========================================================================
    internal class TestHelper
    {
        // ============================== METHOD ==============================
        // PrintSuccess. Accepts a string title and prints out that title was
        // successful.
        // ====================================================================
        private void PrintSuccess(string title)
        {
            Console.WriteLine($"[Success] {title}");
        }

        // ============================== METHOD ==============================
        // PrintFailure. Accepts a string for title, an object for the expected
        // result, and an object for the actual result. Prints out a failure
        // message that title was unsuccessful and what the expected and actual
        // outputs were.
        // ====================================================================
        private void PrintFailure(string title, object expected, object actual)
        {
            Console.WriteLine($"[Failure] {title} | Expected: {expected} | Actual: {actual}");
        }

        // ============================== METHOD ==============================
        // AssertEquals. Checks if two objects are equal and prints out an
        // appropriate success or failure message.
        // ====================================================================
        public void AssertEquals(string title, object expected, object actual)
        {
            if (actual.Equals(expected))
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, expected, actual);
            }
        }

        // ============================== METHOD ==============================
        // AssertNotEquals. Checks if two objects are not equal and prints out
        // an appropriate success or failure message.
        // ====================================================================
        public void AssertNotEquals(string title, object a, object b)
        {
            if (!a.Equals(b))
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, !a.Equals(b), a.Equals(b));
            }
        }

        // ============================== METHOD ==============================
        // AssertTrue. Checks if a bool result is true and prints out an
        // appropriate success or failure message.
        // ====================================================================
        public void AssertTrue(string title, bool result)
        {
            if (result)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, true.ToString(), result.ToString());
            }
        }

        // ============================== METHOD ==============================
        // AssertFalse. Checks if a bool result is false and prints out an
        // appropriate success or failure message.
        // ====================================================================
        public void AssertFalse(string title, bool result)
        {
            if (!result)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, false.ToString(), result.ToString());
            }
        }
    }
}
