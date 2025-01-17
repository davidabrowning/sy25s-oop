namespace PythagoreanMenu
{
    internal class Program
    {

        private const string TEXT_MENU = "\n\n========== Meny ==========" +
            "\n[1] Du har båda sidorna och vill ha hypotenusan" +
            "\n[2] Du har en sida och hypotenusan och vill räkna ut den andra sidan" +
            "\n[0] Avsluta";
        private const string TEXT_CLOSING = "Avslutar programmet.";
        private const string TEXT_LENGTH_HYPOTENEUSE = "Hypotenusans längd: ";
        private const string TEXT_LENGTH_SIDE = "Sidans längd: ";
        private const string WARNING_UNEXPECTED_INPUT = "Varning: Ogiltigt val.";
        private const string WARNING_SIDE_MUST_BE_GREATER_THAN_ZERO = "Varning: Sidans längs måste vara större än 0.";
        private const string WARNING_HYPOTENEUSE_MUST_BE_LONGER_THAN_SIDE_A = "Varning: Hypotenusans längd måste vara större än sidans längd.";
        private const string MENU_PROMPT = "Ditt val: ";
        private const string MENU_TWO_SIDES = "1";
        private const string MENU_ONE_SIDE_AND_HYPOTENEUSE = "2";
        private const string MENU_CLOSE = "0";
        private const string PROMPT_ENTER_SIDE = "Ange sidans längd: ";
        private const string PROMPT_ENTER_HYPOTENEUSE = "Ange hypotenusans längd: ";

        static void Main(string[] args)
        {
            bool runProgram = true;
            while (runProgram)
            {
                ShowMenu();
                switch(Console.ReadLine())
                {
                    case MENU_TWO_SIDES:
                        CalculateHypoteneuse();
                        break;
                    case MENU_ONE_SIDE_AND_HYPOTENEUSE:
                        CalculateSide();
                        break;
                    case MENU_CLOSE:
                        Console.WriteLine(TEXT_CLOSING);
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine(WARNING_UNEXPECTED_INPUT);
                        break;
                }
            }
        }

        // ============================== METOD ===============================
        // ShowMenu. Visar programmets huvudmeny.
        // ====================================================================
        private static void ShowMenu()
        {
            Console.WriteLine(TEXT_MENU);
            Console.Write(MENU_PROMPT);
        }

        // ============================== METOD ===============================
        // CalculateHypoteneuse. Ber användaren mata in sidornas längder och
        // räknar ut hypotenusans längd. Skriver ut resultat.
        // ====================================================================
        private static void CalculateHypoteneuse()
        {
            double sideA = GetSide();
            double sideB = GetSide();
            double hypoteneuse = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            Console.WriteLine(TEXT_LENGTH_HYPOTENEUSE + hypoteneuse);
        }

        // ============================== METOD ===============================
        // CalculateSide. Ber användaren mata in en sidas läng och hypotenusans
        // läng. Räknar då ut andra sidans längd. Skriver ut resultat.
        // ====================================================================
        private static void CalculateSide()
        {
            double sideA = GetSide();
            double hypoteneuse = GetHypoteneuse(sideA);
            double sideB = Math.Sqrt(Math.Pow(hypoteneuse, 2) - Math.Pow(sideA, 2));
            Console.WriteLine(TEXT_LENGTH_SIDE + sideB);
        }

        // ============================== METOD ===============================
        // GetSide. Ber användaren mata in länden på en sida. Måste vara större
        // än 0. Returnerar sidans längd som double.
        // ====================================================================
        private static double GetSide()
        {
            while(true)
            {
                Console.Write(PROMPT_ENTER_SIDE);
                Double.TryParse(Console.ReadLine(), out double result);
                if (result > 0) {
                    return result;
                }
                else
                {
                    Console.WriteLine(WARNING_SIDE_MUST_BE_GREATER_THAN_ZERO);
                }
            }
        }

        // ============================== METOD ===============================
        // GetHypoteneuse. Tar emot längden på en sida. Ber användaren mata in
        // längden på hypotenusan. Måste vara större än sidans längd.
        // Returnerar hypotenusans längd som double.
        // ====================================================================
        private static double GetHypoteneuse(double sideA)
        {
            while(true)
            {
                Console.Write(PROMPT_ENTER_HYPOTENEUSE);
                Double.TryParse(Console.ReadLine(), out double result);
                if (result > sideA)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(WARNING_HYPOTENEUSE_MUST_BE_LONGER_THAN_SIDE_A);
                }
            }
        }

    }
}
