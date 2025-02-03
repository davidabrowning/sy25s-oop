namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            // menu.Display();

            TestRunner testRunner = new TestRunner();
            testRunner.RunTests();
        }
    }
}
