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
        // Returns null as a default.
        // ====================================================================
        public string? GetStringInput()
        {
            return Console.ReadLine();
        }

        // ============================== METHOD ==============================
        // GetIntInput. Reads an int value from the user and returns it.
        // Returns 0 as a default.
        // ====================================================================
        public int GetIntInput()
        {
            string? stringInput = GetStringInput();
            if (stringInput != null && Int32.TryParse(
                stringInput.Trim(), out int intInput))
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
            string? stringInput = GetStringInput();
            if (stringInput != null && decimal.TryParse(
                stringInput.Trim(), out decimal decimalInput))
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
