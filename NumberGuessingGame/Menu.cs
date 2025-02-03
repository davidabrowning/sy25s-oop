using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Menu
    {
        private bool run = true;
        private UserInputRetriever userInputRetriever = new UserInputRetriever();
        public void Display()
        {
            while(run)
            {
                PrintMenu();
                ProcessMenuSelection();
            }
        }
        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Main menu =====");
            Console.WriteLine("[P]lay game: Guess a number from 1 to 100");
            Console.WriteLine("[L]ist high scores");
            Console.WriteLine("[Q]uit");
        }
        private void ProcessMenuSelection()
        {
            switch (userInputRetriever.GetStringInput("Your choice: ", 1, 1).ToUpper())
            {
                case "P":
                    StartGame();
                    break;
                case "L":
                    PrintHighScores();
                    break;
                case "Q":
                    run = false;
                    break;
                default:
                    ProcessMenuSelection(); // Try again
                    break;
            }
        }
        private void StartGame()
        {
            Game game = new Game();
            game.Start();
        }
        private void PrintHighScores()
        {
            Console.Clear();
            SaveManager saveManager = new SaveManager();
            List<Game> savedGames = saveManager.LoadSavedGames();
            List<Game> sortedSavedGames = savedGames.OrderBy(game => game.Guesses).ToList();
            foreach (Game game in sortedSavedGames)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("ENTER to return to main menu.");
            Console.ReadLine();
        }
    }
}
