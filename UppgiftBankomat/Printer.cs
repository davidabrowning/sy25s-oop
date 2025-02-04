using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal static class Printer
    {
        private const string TitleBorder = "==========";
        private const string ReturnConfirmText = "Tryck på ENTER för att fortsätta.";
        internal static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        internal static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine($"\n\t{TitleBorder} {title} {TitleBorder}");
        }
        internal static void PrintSubtitle(string subtitle)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\t{subtitle}");
        }
        internal static void PrintInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t{info}");
        }
        internal static void PrintSuccess(string success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t{success}");
        }
        internal static void PrintWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{warning}");
        }
        internal static void PrintReturnConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\t{ReturnConfirmText}");
            Console.Write("\n\t");
            Console.ReadLine();
        }
        internal static void PrintPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\t{prompt} ");
        }
        internal static void PrintTab()
        {
            Console.Write("\t");
        }
    }
}
