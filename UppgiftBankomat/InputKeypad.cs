namespace UppgiftBankomat
{
    internal class InputKeypad : IInputDevice
    {
        public string GetStringInput()
        {
            string stringInput = Console.ReadLine() ?? "";
            return stringInput.Trim();
        }

        public int GetIntInput()
        {
            string stringInput = GetStringInput();
            if (Int32.TryParse(stringInput, out int intInput))
                return intInput;
            else
                return 0; // Default value
        }

        public decimal GetDecimalInput()
        {
            string stringInput = GetStringInput();
            if (decimal.TryParse(stringInput, out decimal decimalInput))
                return decimalInput;
            else
                return 0.00M; // Default value
        }
    }
}
