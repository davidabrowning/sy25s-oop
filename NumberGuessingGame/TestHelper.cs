using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public static class TestHelper
    {
        public static void PrintSuccess(string title)
        {
            Console.WriteLine($"Success: {title}");
        }
        public static void PrintFailure(string title, string expected, string actual)
        {
            Console.WriteLine($"Failure: {title} | Expected: {expected} | Actual: {actual}");
        }
        public static void AssertTrue(string title, bool actual)
        {
            if(actual)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, false.ToString(), actual.ToString());
            }
        }
        public static void AssertFalse(string title, bool actual)
        {
            if (!actual)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, false.ToString(), actual.ToString());
            }
        }
        public static void AssertEquals(string title, Object expected, Object actual)
        {
            if (expected.Equals(actual))
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, expected.ToString(), actual.ToString());
            }
        }
    }
}
