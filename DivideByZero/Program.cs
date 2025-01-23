namespace DivideByZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                // Collect integer input
                // Check for quit
                Console.Write("Ange ett heltal (Q för att avsluta): ");
                string inmatning1 = Console.ReadLine();
                if (inmatning1.ToUpper() == "Q")
                {
                    run = false;
                    continue;
                }

                Console.Write("Ange ett heltal (Q för att avsluta): ");
                string inmatning2 = Console.ReadLine();
                if (inmatning2.ToUpper() == "Q")
                {
                    run = false;
                    continue;
                }


                // Convert to integers
                int numerator = 0;
                int denominator = 0;
                try
                {
                    numerator = Convert.ToInt32(inmatning1);
                    denominator = Convert.ToInt32(inmatning2);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ogiltig format på minst ett av dina heltal. Försök igen.");
                    continue;
                }

                // Divide
                double result = 0.0;
                try
                {
                    Console.WriteLine($"Num: {numerator}, Denom: {denominator}");
                    if (denominator == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = (double) numerator / denominator;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Kan inte dela med noll. Försök igen.");
                    continue;
                }

                // Output result
                Console.WriteLine($"Resultat: {numerator} / {denominator} = {result}\n");
            }
        }
    }
}
