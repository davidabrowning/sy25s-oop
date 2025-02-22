namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Program. Contains Main method.
    // ========================================================================
    public class Program
    {
        // ============================== METHOD ==============================
        // Main. Entry point for overall program. Creates and starts the
        // Bankomat object.
        // ====================================================================
        public static void Main(string[] args)
        {
            // ============================ REGION ============================
            // Application. Starts the Bankomat application.
            // ================================================================
            #region application            
            Bank bank = new Bank();
            Bankomat bankomat = new Bankomat(bank);
            int accountsToCreate = 10;
            bank.CreateAccounts(accountsToCreate);
            bankomat.Go();
            #endregion application

            // ============================ REGION ============================
            // Tests. Uncomment to run unit tests.
            // ================================================================
            #region tests
            //TestRunner testRunner = new TestRunner();
            //testRunner.Go();
            #endregion tests
        }
    }
}
