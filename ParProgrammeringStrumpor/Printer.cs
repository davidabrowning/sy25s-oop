using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParProgrammeringStrumpor
{
    internal class Printer
    {
        public void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine($"===== {title.ToUpper()} =====");
        }
        public void PrintSubtitle(string subtitle)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n===== {subtitle} =====");
        }
        public void PrintArray(object[] array)
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (object obj in array)
            {
                Console.WriteLine(obj.ToString());
            }
        }
        public void PrintPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{prompt}: ");
        }
        public void PrintUpdate(string update)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(update);
            Thread.Sleep(1000);
        }
        public void PrintInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(info);
        }
        public void ConfirmContinue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n{message}");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
