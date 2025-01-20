using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsWithEnums
{
    // ================================ KLASS =================================
    // Deck. Kortlek som innehåller 
    // ========================================================================
    internal class Deck
    {
        private  const int Suits = 4;
        private const int CardsPerSuit = 13;
        private List<Card> cards;

        // ============================== METOD ===============================
        // Constructor. Initialiserar klassens variabler. 
        // ====================================================================
        public Deck()
        {
            this.cards = InitializeCards();
        }

        // ============================== METOD ===============================
        // Constructor. Initialiserar spelkortlistan. 
        // ====================================================================
        private List<Card> InitializeCards()
        {
            // Initialize temporary card list
            List<Card> newCards = new List<Card>();

            // For each suit...
            for (int suitNum = 0; suitNum < Deck.Suits; suitNum++)
            {

                // Specify suit
                Suit newSuit = Suit.Clubs; // Defaults to clubs
                switch (suitNum)
                {
                    case 0: newSuit = Suit.Clubs; break;
                    case 1: newSuit = Suit.Diamonds; break;
                    case 2: newSuit = Suit.Spades; break;
                    case 3: newSuit = Suit.Hearts; break;
                    default: break;
                }

                // For each card within the suit...
                for (int cardNum = 0; cardNum < Deck.CardsPerSuit; cardNum++)
                {

                    // Add the card to the temporary card list
                    int cardValue = cardNum + 1;
                    Card newCard = new Card(cardValue, newSuit);
                    newCards.Add(newCard);
                }
            }
            return newCards;
        }

        // ============================== METOD ===============================
        // Print. Skriver ut alla kort i kortleken.
        // ====================================================================
        public void Print()
        {
            foreach(Card card in cards)
            {
                Console.Write(card);
            }
        }

        // ============================== METOD ===============================
        // PrintByValue. Skriver ut alla kort i kortleken enligt kortvärde.
        // ====================================================================
        public void PrintByValue()
        {
            foreach(Card card in cards.OrderBy(card =>
                card.Value() * 100 + card.Suit()))
            {
                Console.Write(card);
            }
        }

        // ============================== METOD ===============================
        // PrintBySuit. Skriver ut alla kort i kortleken enligt kortfärg.
        // ====================================================================
        public void PrintBySuit()
        {
            foreach(Card card in cards.OrderBy(card =>
                ((int) card.Suit()) * 100 + card.Value()))
            {
                Console.Write(card);
            }
        }
    }
}
