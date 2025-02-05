using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class InputKeypad
    {
        internal int GetIntInput()
        {
            Int32.TryParse(Console.ReadLine().Trim(), out int userInput);
            return userInput;
        }
        internal Decimal GetDecimalInput()
        {
            Decimal.TryParse(Console.ReadLine().Trim(), out Decimal userInput);
            return userInput;
        }
    }
}
