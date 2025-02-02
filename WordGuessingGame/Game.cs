using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessingGame
{
    internal class Game
    {
        private string Writer;
        private string Guesser;
        private string Phrase;
        internal string PhraseWithGuessedLettersOnly {  get { return GetPhraseWithGuessedLettersOnly(); } }
        internal int Guesses { get { return GuessedLetters.Count; } }
        internal int Misses { get { return CalculateMisses();  } }

        internal List<char> GuessedLetters;
        public bool IsOver { get { return CheckForGameOver(); } }
        public Result Result { get { return new Result(Writer, Guesser, Phrase, Guesses, Misses); } }
        public Game(string writer, string guesser, string phrase)
        {
            Writer = writer;
            Guesser = guesser;
            Phrase = phrase.ToUpper();
            GuessedLetters = new List<char>();
        }
        public void Start()
        {
            while (!IsOver)
            {
                PrintBoard();
                PrintPrompt();
            }
            PrintBoard();
            PrintCongratulations();
        }
        internal void Guess(char letter)
        {
            letter = Char.ToUpper(letter);
            if (GuessedLetters.Contains(letter) == false)
            {
                GuessedLetters.Add(letter);
            }
        }
        private int CalculateMisses()
        {
            int misses = 0;
            foreach (char c in GuessedLetters)
            {
                if(Phrase.Contains(c) == false)
                {
                    misses++;
                }
            }
            return misses;
        }
        private bool CheckForGameOver()
        {
            foreach (char letter in Phrase.ToCharArray())
            {
                if (GuessedLetters.Contains(letter) == false
                    && letter >= 'A'
                    && letter <= 'Z')
                {
                    return false;
                }
            }
            return true;
        }
        private string GetPhraseWithGuessedLettersOnly()
        {
            StringBuilder phraseWithGuessedLettersOnly = new StringBuilder();
            foreach (char letter in Phrase.ToCharArray())
            {
                if (GuessedLetters.Contains(letter)
                    || letter < 'A'
                    || letter > 'Z')
                {
                    phraseWithGuessedLettersOnly.Append(letter);
                }
                else
                {
                    phraseWithGuessedLettersOnly.Append('-');
                }
            }
            return phraseWithGuessedLettersOnly.ToString();
        }
        internal void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("===== Word guessing game =====");
            Console.WriteLine($"Word(s) to guess: {PhraseWithGuessedLettersOnly}");
            Console.WriteLine($"Total misses: {Misses}");
            Console.WriteLine($"Guessed letters: {ShowGuessedLetters()}");
            Console.WriteLine($"Remaining letters: {ShowRemainingLetters()}");
        }
        private void PrintPrompt()
        {
            Console.Write($"{Guesser}'s next guess: ");
            try
            {
                Guess(Convert.ToChar(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Unable to process guess.");
            }
        }
        private void PrintCongratulations()
        {
            Console.WriteLine($"Congratulations, {Guesser}! You solved the puzzle with {Misses} misses.");
            Console.WriteLine("Press ENTER to return to the main menu.");
            Console.ReadLine();
        }
        private string ShowGuessedLetters()
        {
            StringBuilder guessedLetters = new StringBuilder();
            foreach(char letter in GuessedLetters)
            {
                guessedLetters.Append(letter);
            }
            return guessedLetters.ToString();
        }
        private string ShowRemainingLetters()
        {
            StringBuilder remainingLetters = new StringBuilder();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                if (GuessedLetters.Contains(letter) == false)
                {
                    if (Phrase.Contains(letter))
                    {
                        remainingLetters.Append(Char.ToUpper(letter));
                    }
                    else
                    {
                        remainingLetters.Append(Char.ToLower(letter));
                    }
                }
            }
            return remainingLetters.ToString();
        }
    }
}
