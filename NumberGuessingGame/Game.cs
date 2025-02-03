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
        private int targetNumberMin = 1;
        private int targetNumberMax = 100;

        // Private instance variables
        private UserInputRetriever userInputRetriever = new UserInputRetriever();

        // Public properties
        public int Guesses { get; } = 0;

        // Methods
        public static void RunTests()
        {
            // Variables that can be reused
            string title;
            Game game;

            Console.WriteLine("Running Game tests:");

            title = "Guesses starts at 0";
            game = new Game();
            TestHelper.AssertEquals(title, 0, game.Guesses);
        }
    }
}
