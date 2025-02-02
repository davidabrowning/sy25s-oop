using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessingGame
{
    public class GameLauncher
    {
        private bool keepPlaying;
        private ResultLoader resultLoader;
        public GameLauncher()
        {
            keepPlaying = true;
            resultLoader = new ResultLoader("Results.json");
        }
        public void Go()
        {
            do
            {
                ShowMenu();
                HandleMenuSelection();
            } while (keepPlaying);
            Console.WriteLine("Thank you for playing! Hej då!");
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Main menu =====");
            Console.WriteLine("[P]lay a round of the word guessing game");
            Console.WriteLine("[L]ist high scores");
            Console.WriteLine("[Q]uit");
        }
        private void HandleMenuSelection()
        {
            switch (Console.ReadLine().ToUpper())
            {
                case "P":
                    Console.Clear();
                    PlayAGame();
                    break;
                case "L":
                    Console.Clear();
                    ListHighScores();
                    break;
                case "Q":
                    Console.Clear();
                    keepPlaying = false;
                    break;
                default:
                    Console.WriteLine("Unknown menu selection. Press ENTER to try again.");
                    Console.ReadLine();
                    break;
            }
        }
        private void PlayAGame()
        {
            string writer = "";
            string guesser = "";
            string phrase = "";

            Console.WriteLine("===== Game setup =====");
            while (writer.Length < 2)
            {
                Console.Write("Writer's name: ");
                writer = Console.ReadLine() ?? "";
            }
            while (guesser.Length < 2)
            {
                Console.Write("Guesser's name: ");
                guesser = Console.ReadLine() ?? "";
            }
            while (phrase.Length < 5)
            {
                Console.Write("Word or phrase to guess (at least 5 letters, guesser please look away): ");
                phrase = Console.ReadLine() ?? "";
            }

            Game game = new Game(writer, guesser, phrase);
            game.Start();
            SaveGameResults(game);
        }
        private void SaveGameResults(Game game)
        {
            resultLoader.AddResult(game.Result);
        }
        private void ListHighScores()
        {
            int resultCounter = 1;
            List<Result> results = resultLoader.Results;
            IEnumerable<Result> sortedResults = results.AsQueryable().OrderBy(result => result.Misses);

            Console.WriteLine("===== High scores =====");
            foreach(Result result in sortedResults)
            {
                Console.WriteLine($"{resultCounter++}: {result}");
            }
            Console.WriteLine("\nPress ENTER to return to main menu.");
            Console.ReadLine();
        }
    }
}
