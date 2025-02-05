using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class OutputScreen
    {
        // Constants
        private const string TitleBorder = "==========";
        private const string ReturnConfirmText = "Tryck ENTER för att fortsätta.";

        // Methods
        internal void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        internal void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine($"\n\t{TitleBorder} {title} {TitleBorder}");
        }
        internal void PrintSubtitle(string subtitle)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\t{subtitle}");
        }
        internal void PrintInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t{info}");
        }
        internal void PrintSuccess(string success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t{success}");
        }
        internal void PrintWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{warning}");
        }
        internal void PrintReturnConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\t{ReturnConfirmText}");
            Console.Write("\n\t");
            Console.ReadLine();
        }
        internal void PrintPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\t{prompt} ");
        }
        internal void PrintTab()
        {
            Console.Write("\t");
        }
    }
}
