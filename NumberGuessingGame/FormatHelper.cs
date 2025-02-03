using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public static class FormatHelper
    {
        public static void PrintTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"===== {title} =====");
        }
        public static void PrintMenuReturnConfirmation()
        {
            Console.WriteLine("Press ENTER to return.");
            Console.ReadLine();
        }
    }
}
