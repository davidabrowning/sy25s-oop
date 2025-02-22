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
    internal class InputKeypad : IInputDevice
    {

        // ============================== METHOD ==============================
        // GetStringInput. Reads a string value from the user and returns it.
        // Returns "" as a default.
        // ====================================================================
        public string GetStringInput()
        {
            string stringInput = Console.ReadLine() ?? "";
            return stringInput.Trim();
        }

        // ============================== METHOD ==============================
        // GetIntInput. Reads an int value from the user and returns it.
        // Returns 0 as a default.
        // ====================================================================
        public int GetIntInput()
        {
            string stringInput = GetStringInput();
            if (Int32.TryParse(stringInput, out int intInput))
            {
                return intInput;
            }
            else
            {
                return 0;
            }
        }

        // ============================== METHOD ==============================
        // GetDecimalInput. Reads a decimal value from the user and returns it.
        // Returns 0.00 as a default.
        // ====================================================================
        public decimal GetDecimalInput()
        {
            string stringInput = GetStringInput();
            if (decimal.TryParse(stringInput, out decimal decimalInput))
            {
                return decimalInput;
            }
            else
            {
                return 0.00M;
            }
        }
    }
}
