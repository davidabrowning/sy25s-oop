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
            int accountsToCreate = 10;
            Bank bank = new Bank();
            bank.CreateAccounts(accountsToCreate);
            Bankomat bankomat = new Bankomat(bank);
            bankomat.Go();

            // The below TestRunner and Go() calls can be uncommented
            // to run unit tests. In that case you probably want to comment out
            // the new Bankomat() and bankomat.Go() lines above.
            //TestRunner testRunner = new TestRunner();
            //testRunner.Go();
        }
    }
}
