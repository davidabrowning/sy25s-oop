using System.Diagnostics.Metrics;

namespace ForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa en Array med 5 namn
            string[] namn = { "Alan", "Beth", "Carl", "Daniel", "Edith" };

            // Loopa igenom först med for och skriv ut namnen
            Console.WriteLine("\n\nNamn från array med for:");
            for (int n = 0; n < namn.Length; n++)
            {
                Console.Write(namn[n] + " ");
            }

            // Loopa igenom först med for och skriv ut namnen
            Console.WriteLine("\n\nNamn från array med foreach:");
            foreach(string n in namn)
            {
                Console.Write(n + " ");
            }

            // Sen gör ni en till loop som foreach på er Array med.ToList() efter Array namnet
            // names[].ToList()
            Console.WriteLine("\n\nNamn från list med for:");
            for (int n = 0; n < namn.ToList().Count(); n++)
            {
                Console.Write(namn[n] + " ");
            }

                // Sen gör ni en till loop som foreach på er Array med.ToList() efter Array namnet
                // names[].ToList()
                Console.WriteLine("\n\nNamn från list med foreach:");
            foreach(string n in namn.ToList())
            {
                Console.Write(n + " ");
            }

            Console.WriteLine("\n\n");

        }
    }
}
