using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class UserInputRetriever
    {
        internal int GetIntInput(string prompt)
        {
            Printer.PrintPrompt(prompt);
            Int32.TryParse(Console.ReadLine().Trim(), out int userInput);
            return userInput;
        }
        internal Decimal GetDecimalInput(string prompt)
        {
            Printer.PrintPrompt(prompt);
            Decimal.TryParse(Console.ReadLine().Trim(), out Decimal userInput);
            return userInput;
        }
    }
}
