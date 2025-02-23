namespace UppgiftBankomat
{
    internal class TestHelper
    {
        public void AssertEquals(string title, object expected, object actual)
        {
            if (actual.Equals(expected))
                PrintSuccess(title);
            else
                PrintFailure(title, expected, actual);
        }

        public void AssertNotEquals(string title, object a, object b)
        {
            if (!a.Equals(b))
                PrintSuccess(title);
            else
                PrintFailure(title, !a.Equals(b), a.Equals(b));
        }

        public void AssertTrue(string title, bool result)
        {
            if (result)
                PrintSuccess(title);
            else
                PrintFailure(title, true.ToString(), result.ToString());
        }

        public void AssertFalse(string title, bool result)
        {
            if (!result)
                PrintSuccess(title);
            else
                PrintFailure(title, false.ToString(), result.ToString());
        }

        private void PrintSuccess(string title)
        {
            Console.WriteLine($"[Success] {title}");
        }

        private void PrintFailure(string title, object expected, object actual)
        {
            Console.WriteLine($"[Failure] {title} | Expected: {expected} | Actual: {actual}");
        }
    }
}
