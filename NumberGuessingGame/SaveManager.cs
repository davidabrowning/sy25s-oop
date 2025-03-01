﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class SaveManager
    {
        // Private constants
        private const string DefaultFilename = "SavedGames.json";
        private const string WarningUnableToSaveGame = "Unable to save game.";

        // Private variables
        private string filename;

        // Public properties

        // Constructors
        public SaveManager() : this(DefaultFilename) { }
        public SaveManager(string filename)
        {
            this.filename = filename;
        }

        // Methods
        public void Save(Game game)
        {
            List<Game> savedGames = LoadSavedGames();
            savedGames.Add(game);
            string savedGamesAsJsonString = JsonSerializer.Serialize(savedGames);
            try
            {
                File.WriteAllText(filename, savedGamesAsJsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(WarningUnableToSaveGame);
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteSavedGames()
        {
            File.Delete(filename);
        }
        public List<Game> LoadSavedGames()
        {
            List<Game> gamesAsList;
            try
            {
                string gamesAsJsonString = File.ReadAllText(filename);
                gamesAsList = JsonSerializer.Deserialize<List<Game>>(gamesAsJsonString);
            }
            catch (Exception e)
            {
                gamesAsList = new List<Game>();
            }
            return gamesAsList;
        }
        public static void RunTests()
        {
            // Variables to reuse
            string title;
            Game game = new Game();
            List<Game> savedGames = new List<Game>();
            SaveManager saveManager = new SaveManager("SavedGames_Test.json");

            Console.WriteLine("Running SaveManager tests...");

            title = "New file has list size of 0";
            saveManager.DeleteSavedGames();
            savedGames = saveManager.LoadSavedGames();
            TestHelper.AssertEquals(title, 0, savedGames.Count);

            title = "File with two saved games has size of 2";
            saveManager.DeleteSavedGames();
            saveManager.Save(new Game());
            saveManager.Save(new Game());
            savedGames = saveManager.LoadSavedGames();
            TestHelper.AssertEquals(title, 2, savedGames.Count);

        }
    }
}
