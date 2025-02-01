using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessingGame
{
    public class TestRunner
    {
        public static void RunTests()
        {
            // Variables to reuse
            string title;
            Result result;
            List<Result> results;
            ResultLoader resultLoader = new ResultLoader("Results_Test.json");
            Game game;

            title = "Result equals result's phrase";
            result = new Result("John", "Jane", "TEST PHRASE", 10);
            AssertTrue(title, result.Phrase.Equals("TEST PHRASE"));

            title = "ResultHelper.Filename is correct";
            AssertEquals(title, "Results_Test.json", resultLoader.Filename);

            title = "ResultHelper.Results does not initially contain result";
            resultLoader.DeleteFile();
            result = new Result("John", "Jane", "Test", 5);
            results = resultLoader.Results;
            AssertFalse(title, results.Contains(result));

            title = "ResultHelper.Results contains added result";
            resultLoader.DeleteFile();
            result = new Result("John", "Jane", "Test", 5);
            resultLoader.AddResult(result);
            results = resultLoader.Results;
            AssertTrue(title, resultLoader.Results.Contains(result));

            title = "Game is not initially over";
            game = new Game("Writer", "Guesser", "AAAABBBB");
            AssertFalse(title, game.IsOver);

            title = "Guessed letter is contained in Game.GuessedLetters";
            game = new Game("Writer", "Guesser", "AAAABBBB");
            game.Guess('T');
            AssertTrue(title, game.GuessedLetters.Contains('T'));

            title = "Game is over after guessing all letters";
            game = new Game("Writer", "Guesser", "AAAA BBBB");
            game.Guess('A');
            game.Guess('B');
            AssertTrue(title, game.IsOver);

            title = "Game.Guesses is 2 after guessing twice";
            game = new Game("Writer", "Guesser", "ABCDEFG");
            game.Guess('A');
            game.Guess('Z');
            AssertEquals(title, 2, game.Guesses);

            title = "Game.Guesses is 1 after guessing the same letter twice";
            game = new Game("Writer", "Guesser", "ABCDEFG");
            game.Guess('Z');
            game.Guess('Z');
            AssertEquals(title, 1, game.Guesses);

            title = "Phrase with guessed letters does not have unguessed letter";
            game = new Game("Writer", "Guesser", "ABC DEFG");
            game.Guess('A');
            AssertFalse(title, game.PhraseWithGuessedLettersOnly.ToCharArray().Contains('B'));

            title = "Phrase with guessed letters has guessed letter";
            game = new Game("Writer", "Guesser", "ABC DEFG");
            game.Guess('A');
            game.Guess('B');
            AssertTrue(title, game.PhraseWithGuessedLettersOnly.ToCharArray().Contains('B'));

            title = "Various print tests";
            game = new Game("John Doe", "Jane Doe", "Osage oil boom");
            game.Start();
        }
        private static void PrintSuccess(string title)
        {
            Console.WriteLine($"Success: {title}");
        }
        private static void PrintFailure(string title, string expected, string actual)
        {
            Console.WriteLine($"Failure: {title} | Expected: {expected} | Actual: {actual}");
        }
        private static void AssertTrue(string title, bool result)
        {
            if (result)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, true.ToString(), result.ToString());
            }
        }
        private static void AssertFalse(string title, bool result)
        {
            if (!result)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, false.ToString(), result.ToString());
            }
        }
        private static void AssertEquals(string title, Object expected, Object actual)
        {
            if (expected.Equals(actual))
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, expected.ToString(), actual.ToString());
            }
        }
    }
}
