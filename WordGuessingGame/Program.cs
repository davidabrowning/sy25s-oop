namespace WordGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestRunner.RunTests();

            GameLauncher gameLauncher = new GameLauncher();
            //gameLauncher.Go();
        }
    }
}
