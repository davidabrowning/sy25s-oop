﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // OutputScreen. Displays output messages from the Bankomat.
    // ========================================================================
    internal class OutputScreen
    {
        // Constants
        private const string TitleBorder = "==========";
        private const string ConfirmContinue = "Tryck ENTER för att fortsätta.";

        // ============================== METHOD ==============================
        // Reset. Resets the Console colors and clears it.
        // ====================================================================
        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        // ============================== METHOD ==============================
        // PrintTitle. Clears the Console and outputs a title message.
        // ====================================================================
        public void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine($"\n\t{TitleBorder} {title} {TitleBorder}");
        }

        // ============================== METHOD ==============================
        // PrintInfo. Outputs an informational message.
        // ====================================================================
        public void PrintInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t{info}");
        }

        // ============================== METHOD ==============================
        // PrintSuccess. Outputs a success message.
        // ====================================================================
        public void PrintSuccess(string success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\t{success}");
        }

        // ============================== METHOD ==============================
        // PrintWarning. Outputs a warning message.
        // ====================================================================
        public void PrintWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\t{warning}");
        }

        // ============================== METHOD ==============================
        // PrintContinueConfirmation. Outputs a message asking the user to press
        // ENTER to continue. Waits for the user to enter a new line before
        // continuing.
        // ====================================================================
        public void PrintContinueConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\t{ConfirmContinue}");
            Console.Write("\n\t");
            Console.ReadLine();
        }

        // ============================== METHOD ==============================
        // PrintPrompt. Outputs a user prompt.
        // ====================================================================
        public void PrintPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\t{prompt} ");
        }

        // ============================== METHOD ==============================
        // PrintTab. Outputs a buffer tab.
        // ====================================================================
        public void PrintTab()
        {
            Console.Write("\t");
        }
    }
}
