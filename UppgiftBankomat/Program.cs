namespace UppgiftBankomat
{
    public class Program
    {
        // Constants
        private const int AccountsToCreate = 10;

        static void Main(string[] args)
        {
            Bankomat bankomat = new Bankomat(AccountsToCreate);
            bankomat.Start();

            // The below TestRunner and RunAllTests() call can be uncommented
            // to run unit tests. In that case you probably want to comment out
            // the new Bankomat() and bankomat.Start() lines above.
            //TestRunner testRunner = new TestRunner();
            //testRunner.RunAllTests();
        }
    }
}
