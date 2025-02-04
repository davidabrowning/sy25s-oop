namespace UppgiftBankomat
{
    public class Program
    {
        // Constants
        private const int AccountsToCreate = 10;
        private const string GoodbyeTitle = "Bankomat huvudmeny";
        private const string GoodbyeText1 = "Programmet avslutas...";
        private const string GoodbyeText2 = "Tack och hej då!";

        static void Main(string[] args)
        {
            
            Printer.ResetConsoleColor();
            Console.Clear();

            StartBankomat();
            //RunTests();
        }
        private static void StartBankomat()
        {
            Bankomat bankomat = new Bankomat(AccountsToCreate);
            bankomat.Start();

            // Say goodbye and close program
            Console.Clear();
            Printer.PrintTitle(GoodbyeTitle);
            Printer.PrintInfo(GoodbyeText1);
            Printer.PrintInfo(GoodbyeText2);
            Thread.Sleep(2000);
            Printer.ResetConsoleColor();
            Console.Clear();
        }
        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.RunAllTests();
        }
    }
}
