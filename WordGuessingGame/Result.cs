using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WordGuessingGame
{
    public class Result
    {
        public string Writer { get; private set; }
        public string Guesser { get; private set; }
        public string Phrase { get; private set; }
        public int Guesses { get; private set; }
        public DateTime DateOfGame { get; private set; }
        public Result(string writer, string guesser, string phrase, int guesses)
        {
            Writer = writer;
            Guesser = guesser;
            Phrase = phrase;
            Guesses = guesses;
            DateOfGame = DateTime.Now;
        }
        public override string ToString()
        {
            return $"\"{Phrase}\" guessed by {Guesser} in {Guesses} guesses (written by {Writer}) {DateOfGame.Day} {GetShortMonth(DateOfGame.Month)} {DateOfGame.Year}";
        }
        private string GetShortMonth(int monthNum)
        {
            switch (monthNum)
            {
                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default: return "Unknown";
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Result r2 = (Result)obj;
            if ( this.Writer != r2.Writer 
                || this.Guesser != r2.Guesser
                || this.Phrase != r2.Phrase
                || this.Guesses != r2.Guesses
                || this.DateOfGame.Equals(r2.DateOfGame))
            {
                return false;
            }
            return true;
        }
    }
}
