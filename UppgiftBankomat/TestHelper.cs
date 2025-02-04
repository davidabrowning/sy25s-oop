using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal static class TestHelper
    {
        private static void PrintSuccess(string title)
        {
            Printer.PrintInfo($"[Success] {title}");
        }
        private static void PrintFailure(string title, object expected, object actual)
        {
            Printer.PrintWarning($"[Failure] {title} | Expected: {expected} | Actual: {actual}");
        }
        internal static void AssertEquals(string title, object expected, object actual)
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
        internal static void AssertNotEquals(string title, object a, object b)
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
        internal static void AssertTrue(string title, bool result)
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
        internal static void AssertFalse(string title, bool result)
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
