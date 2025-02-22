namespace Lektion20250121
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            SkrivUtFyrkantTriangeln();
            Console.WriteLine();

            SkrivUtInmatningPlusTio();
            Console.WriteLine();

            SkrivUtFemNamn();
            Console.WriteLine();

            Console.WriteLine("Hej då!");
        }

        static void SkrivUtFemNamn()
        {
            string[] familjenSimpson = new string[5];
            familjenSimpson[0] = "Homer";
            familjenSimpson[1] = "Marge";
            familjenSimpson[2] = "Bart";
            familjenSimpson[3] = "Lisa";
            familjenSimpson[4] = "Maggie";

            Console.WriteLine("Familjen Simpson:");
            for (int namn = 0; namn < familjenSimpson.Length; namn++)
            {
                if (namn %2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(familjenSimpson[namn]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SkrivUtInmatningPlusTio()
        {
            // Variabler
            bool giltigInmatning;
            int startSiffra = 0;
            int antalGånger = 0;

            // Be om inmatning av användaren:
            // Vilket startvärde?
            do
            {
                Console.Write("Vilket startvärde: ");
                try
                {
                    startSiffra = Convert.ToInt32(Console.ReadLine());
                    giltigInmatning = true;
                }
                catch (Exception ex)
                {
                    giltigInmatning = false;
                }
            } while (!giltigInmatning);

            // Be om inmatning av användaren:
            // Hur många gånger?
            do
            {
                Console.Write("Hur många gånger: ");
                try
                {
                    antalGånger = Convert.ToInt32(Console.ReadLine());
                    if (antalGånger > 0)
                    {
                        giltigInmatning = true;
                    } else
                    {
                        giltigInmatning = false;
                    }
                }
                catch (Exception ex)
                {
                    giltigInmatning = false;
                }
            } while (!giltigInmatning);

            // Skriv ut resultat
            for (int i = 0; i < antalGånger; i++)
            {
                int resultat = startSiffra + 1 + i;
                Console.Write(resultat + " ");
            }
            Console.WriteLine();
        }

        static void SkrivUtFyrkantTriangeln()
        {

            // Variabler
            int antalRader = 10;
            int antalBlankslag = 19;
            int antalFyrkant = 1;

            // För varje rad...
            for (int rad = 0; rad < antalRader; rad++)
            {

                // Skriv ut blankslag
                for (int blankSlag = 0; blankSlag < antalBlankslag; blankSlag++)
                {
                    Console.Write(" ");
                }

                // Skriv ut fyrkant
                for (int fyrkant = 0; fyrkant < antalFyrkant; fyrkant++)
                {
                    Console.Write("#");
                }

                // Avluta rad och uppdatera antal blankslag samt fyrkant
                Console.Write("\n");
                antalBlankslag--;
                antalFyrkant += 2;
            }
        }
    }
}
