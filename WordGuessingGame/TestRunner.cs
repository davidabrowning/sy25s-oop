using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessingGame
{
    public class TestRunner
    {
        public static void RunTests()
        {
            // Variables to reuse
            string title;
            Result result;
            List<Result> results;
            ResultLoader resultLoader = new ResultLoader("Results_Test.json");

            title = "Result equals result's phrase";
            result = new Result("John", "Jane", "TEST PHRASE", 10);
            AssertTrue(title, result.Phrase.Equals("TEST PHRASE"));

            title = "ResultHelper.Filename is correct";
            AssertEquals(title, "Results_Test.json", resultLoader.Filename);

            title = "ResultHelper.Results does not initially contain result";
            resultLoader.DeleteFile();
            result = new Result("John", "Jane", "Test", 5);
            results = resultLoader.Results;
            AssertFalse(title, results.Contains(result));

            title = "ResultHelper.Results contains added result";
            resultLoader.DeleteFile();
            result = new Result("John", "Jane", "Test", 5);
            resultLoader.AddResult(result);
            results = resultLoader.Results;
            AssertTrue(title, resultLoader.Results.Contains(result));


        }
        private static void PrintSuccess(string title)
        {
            Console.WriteLine($"Success: {title}");
        }
        private static void PrintFailure(string title, string expected, string actual)
        {
            Console.WriteLine($"Failure: {title} | Expected: {expected} | Actual: {actual}");
        }
        private static void AssertTrue(string title, bool result)
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
        private static void AssertFalse(string title, bool result)
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
        private static void AssertEquals(string title, Object expected, Object actual)
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
