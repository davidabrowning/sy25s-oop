using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace NumberGuessingGame
{
    public class Game
    {
        // Private constants
        private static int targetMin = 1;
        private static int targetMax = 100;

        // Private instance variables
        private UserInputRetriever uIR = new UserInputRetriever();

        // Public properties
        public int LatestGuess { get; private set; }
        public int Guesses { get; private set; } = 0;
        public int TargetNumber { get; private set; } = targetMin - 1;
        public bool IsOver {  get { return LatestGuess == TargetNumber; } }

        // Constructors
        [JsonConstructor]
        public Game(int latestGuess, int guesses, int targetNumber)
        {
            LatestGuess = latestGuess;
            Guesses = guesses;
            TargetNumber = targetNumber;
        }
        public Game()
        {
            TargetNumber = GenerateTargetNumber();
        }

        // Methods
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("===== Play game =====");
            while (IsOver == false)
            {
                int nextGuess = uIR.GetIntInput("Your guess: ", targetMin, targetMax);
                Guess(nextGuess);
                Console.WriteLine(GetStatus());
            }
            Save();
            Console.WriteLine("ENTER to return to main menu");
            Console.ReadLine();
        }
        private int GenerateTargetNumber()
        {
            Random rand = new Random();
            return rand.Next(targetMin, targetMax + 1);
        }
        private void Guess(int guess)
        {
            LatestGuess = guess;
            Guesses++;
        }
        private string GetStatus()
        {
            if (LatestGuess < TargetNumber)
            {
                return "Too low!";
            }
            if (LatestGuess > TargetNumber)
            {
                return "Too high";
            }
            return "You guessed it!";
        }
        private void Save()
        {
            SaveManager saveManager = new SaveManager();
            saveManager.Save(this);
        }
        public override string? ToString()
        {
            return $"Guessed {TargetNumber} in {Guesses} guesses";
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

            title = "Status includes too low when guess is too low";
            game = new Game();
            game.TargetNumber = 5;
            game.Guess(3);
            TestHelper.AssertTrue(title, game.GetStatus().ToLower().Contains("too low"));

            title = "Status includes too high when guess is too high";
            game = new Game();
            game.TargetNumber = 5;
            game.Guess(7);
            TestHelper.AssertTrue(title, game.GetStatus().ToLower().Contains("too high"));

            title = "Status includes neither too low nor too high when guess is correct";
            game = new Game();
            game.TargetNumber = 5;
            game.Guess(5);
            TestHelper.AssertFalse(title, game.GetStatus().ToLower().Contains("too low") || game.GetStatus().ToLower().Contains("too high"));

            title = "Game is over if LatestGuess == TargetNumber";
            game = new Game();
            game.TargetNumber = 5;
            game.Guess(5);
            TestHelper.AssertTrue(title, game.IsOver);
        }
    }
}
