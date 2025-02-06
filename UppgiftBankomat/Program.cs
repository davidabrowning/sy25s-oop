namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Program. Contains Main method.
    // ========================================================================
    public class Program
    {
        // Constants
        private const int AccountsToCreate = 10;

        // ============================== METHOD ==============================
        // Main. Entry point for overall program. Creates and starts the
        // Bankomat object.
        // ====================================================================
        public static void Main(string[] args)
        {
            //Bankomat bankomat = new Bankomat(AccountsToCreate);
            //bankomat.Start();

            // The below TestRunner and Go() calls can be uncommented
            // to run unit tests. In that case you probably want to comment out
            // the new Bankomat() and bankomat.Start() lines above.
            TestRunner testRunner = new TestRunner();
            testRunner.Go();
        }
    }
}
