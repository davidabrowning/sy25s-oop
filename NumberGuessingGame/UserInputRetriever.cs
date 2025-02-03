using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class UserInputRetriever
    {
        public string GetStringInput(string prompt, int min, int max)
        {
            string input = "";
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
            } while (input.Length < min || input.Length > max);
            return input;
        }
        public int GetIntInput(string prompt, int min, int max)
        {
            int input = 0;
            do
            {
                Console.Write(prompt);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    continue; // Try again
                }
            } while (input < min || input > max);
            return input;
        }
    }
}
