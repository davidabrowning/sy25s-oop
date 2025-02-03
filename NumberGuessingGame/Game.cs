using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Game
    {
        // Private constants
        private static int targetNumberMin = 1;
        private static int targetNumberMax = 100;

        // Private instance variables
        private UserInputRetriever userInputRetriever = new UserInputRetriever();

        // Public properties
        public int LatestGuess { get; private set; } = targetNumberMin - 1;
        public int Guesses { get; private set; } = 0;
        public int TargetNumber { get; private set; }

        // Constructors
        public Game()
        {
            TargetNumber = GenerateTargetNumber();
        }

        // Methods
        private int GenerateTargetNumber()
        {
            Random rand = new Random();
            return rand.Next(targetNumberMin, targetNumberMax + 1);
        }
        private void Guess(int guess)
        {
            LatestGuess = guess;
            Guesses++;
        }
        public static void RunTests()
        {
            // Variables that can be reused
            string title;
            Game game;

            Console.WriteLine("Running Game tests:");

            title = "Guesses starts at 0";
            game = new Game();
            TestHelper.AssertEquals(title, 0, game.Guesses);

            title = "Guesses is 1 after 1 guess";
            game = new Game();
            game.Guess(5);
            TestHelper.AssertEquals(title, 1, game.Guesses);

            title = "LatestGuess reflects most recent guess";
            game = new Game();
            game.Guess(7);
            TestHelper.AssertEquals(title, 7, game.LatestGuess);
        }
    }
}
