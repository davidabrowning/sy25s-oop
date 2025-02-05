namespace UppgiftBankomat
{
    public class Program
    {
        // Constants
        private const int AccountsToCreate = 10;

        static void Main(string[] args)
        {
            StartBankomat();
            //RunTests();
        }
        private static void StartBankomat()
        {
            Bankomat bankomat = new Bankomat(AccountsToCreate);
            bankomat.Start();
        }
        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.RunAllTests();
        }
    }
}
