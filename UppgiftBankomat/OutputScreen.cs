using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // OutputScreen. Displays messages to the user on the virtual screen.
    // ========================================================================
    internal class OutputScreen : IOutputDevice
    {
        // Constants
        private const int TitleHeadingWidth = 40;
        private const string TitleBorder = "#";
        private const string TitleSpacer = " ";
        private const string ConfirmContinue = "Tryck ENTER för att fortsätta.";

        // ============================== METHOD ==============================
        // ResetSettings. Resets the Console colors and clears it.
        // ====================================================================
        public void ResetSettings()
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

            PrintTitleBorder();
            PrintTitleSpacerLeft(title);
            Console.Write(title);
            PrintTitleSpacerRight(title);
            PrintTitleBorder();
        }

        // ============================== METHOD ==============================
        // PrintTItleBorder. Outputs the border above and below the title.
        // ====================================================================
        private void PrintTitleBorder()
        {
            Console.Write("\n\t");
            for (int i = 0; i < TitleHeadingWidth; i++)
            {
                Console.Write(TitleBorder);
            }
            Console.WriteLine();
        }

        // ============================== METHOD ==============================
        // PrintTitleSpacerLeft. Outputs the buffer space to the left of the
        // title.
        // ====================================================================
        private void PrintTitleSpacerLeft(string title)
        {
            Console.Write($"\t##");
            for (int i = 0; i < (TitleHeadingWidth - title.Length - 4) / 2; i++)
            {
                Console.Write(TitleSpacer);
            }
        }

        // ============================== METHOD ==============================
        // PrintTitleSpacerRight. Outputs the buffer space to the right of the
        // title.
        // ====================================================================
        private void PrintTitleSpacerRight(string title)
        {
            for (int i = 0; i < (TitleHeadingWidth - title.Length - 3) / 2; i++)
            {
                Console.Write(TitleSpacer);
            }
            Console.Write("##");
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
            Console.WriteLine($"\t{success}");
        }

        // ============================== METHOD ==============================
        // PrintWarning. Outputs a warning message.
        // ====================================================================
        public void PrintWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{warning}");
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
    }
}
