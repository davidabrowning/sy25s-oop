using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsWithEnums
{

    // ================================ KLASS =================================
    // Card. Innehåller ett spelkort inklusivt värde, namn och färg.
    // ========================================================================
    internal class Card
    {
        // Properties
        private int value;
        private string name;
        private Suit suit;

        // Konstruktor
        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        // ============================== METOD ===============================
        // Value. Returnerar kortets värde.
        // ====================================================================
        public int Value()
        {
            return value;
        }

        // ============================== METOD ===============================
        // Suit. Returnerar kortets färg som enum.
        // ====================================================================
        public Suit Suit()
        {
            return suit;
        }

        // ============================== METOD ===============================
        // Name. Konverterar kortets värde till en sträng. Returnerar sträng-
        // värdet.
        // ====================================================================
        private string Name()
        {
            switch (this.value)
            {
                case 1: return "Ace";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                case 10: return "Ten";
                case 11: return "Jack";
                case 12: return "Queen";
                case 13: return "King";
                default: return "";
            }
        }

        // ============================== METOD ===============================
        // ToString. Override-metod för utskrivning av kortet.
        // ====================================================================
        public override string ToString()
        {
            return "[ " + this.Name() + " of " + this.suit + " ]";
        }
    }
}
