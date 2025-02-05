using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // InputKeypad. Collects user input.
    // ========================================================================
    internal class InputKeypad
    {

        // ============================== METHOD ==============================
        // GetIntInput. Reads an int value from the user and returns it.
        // ====================================================================
        internal int GetIntInput()
        {
            Int32.TryParse(Console.ReadLine().Trim(), out int userInput);
            return userInput;
        }

        // ============================== METHOD ==============================
        // GetdecimalInput. Reads a decimal value from the user and returns it.
        // ====================================================================
        internal decimal GetdecimalInput()
        {
            decimal.TryParse(Console.ReadLine().Trim(), out decimal userInput);
            return userInput;
        }
    }
}
