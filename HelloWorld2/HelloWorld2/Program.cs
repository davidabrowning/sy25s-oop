using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ================================ NAMESPACE =================================
// HelloWorld2. Program som skriver ut Hello World.
// ============================================================================
namespace HelloWorld2
{

    // ================================ KLASS =================================
    // Program. Innehåller Main.
    // ========================================================================
    internal class Program
    {

        // ============================== METOD ===============================
        // Main. Start på programmet.
        // ====================================================================
        static void Main(string[] args)
        {
            string hälsning = "Hello world!";
            Greet(hälsning);
        }

        // ============================== METOD ===============================
        // Greet. Skriver ut ett meddelande.
        // ====================================================================
        private static void Greet(string meddelande)
        {
            Console.WriteLine("Början på hälsning.");
            Console.WriteLine(meddelande);
            Console.WriteLine("Slut på hälsning.");
        }
    }
}
