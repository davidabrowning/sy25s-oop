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
            Console.WriteLine("[P]lay game");
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
            Console.WriteLine("Starting game...");
        }
        private void PrintHighScores()
        {
            Console.WriteLine("Printing high scores...");
        }
    }
}
