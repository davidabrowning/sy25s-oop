namespace PlayingCardsWithEnums
{
    // ================================ KLASS =================================
    // Program. Innehåller Main-metoden.
    // ========================================================================
    internal class Program
    {

        // ============================== METOD ===============================
        // Main. Start på programmet. Skapar en kortlek. Skriver ut kortleken
        // som skapad och enligt kortvärde samt färg.
        // ====================================================================
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine("\n\nOrdering by value:");
            deck.PrintByValue();
            Console.WriteLine("\n\nOrdering by suit:");
            deck.PrintBySuit();
        }
    }
}
