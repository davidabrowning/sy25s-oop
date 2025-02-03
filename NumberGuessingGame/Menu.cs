using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Menu
    {
        // Private constants
        private const string PageTitle = "Main menu";
        private const string MenuTextPlay = "[P]lay game: Guess a number from 1 to 100";
        private const string MenuTextList = "[L]ist high scores";
        private const string MenuTextQuit = "[Q]uit";
        private const string MenuKeyPlay = "P";
        private const string MenuKeyList = "L";
        private const string MenuKeyQuit = "Q";
        private const string PromptMenuChoice = "Your choice:";

        // Private variables
        private bool run = true;
        private UserInputRetriever userInputRetriever = new UserInputRetriever();

        // Public properties

        // Constructors

        // Methods
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
            FormatHelper.PrintTitle(PageTitle);
            Console.WriteLine(MenuTextPlay);
            Console.WriteLine(MenuTextList);
            Console.WriteLine(MenuTextQuit);
        }
        private void ProcessMenuSelection()
        {
            switch (userInputRetriever.GetStringInput(PromptMenuChoice, 1, 1).ToUpper())
            {
                case MenuKeyPlay:
                    StartGame();
                    break;
                case MenuKeyList:
                    PrintHighScores();
                    break;
                case MenuKeyQuit:
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
            FormatHelper.PrintMenuReturnConfirmation();
        }
    }
}
