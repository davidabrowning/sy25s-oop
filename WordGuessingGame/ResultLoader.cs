using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace WordGuessingGame
{
    internal class ResultLoader
    {
        internal string Filename { get; private set; }
        internal List<Result>? Results { get { return LoadResultsFromFile(); } }
        public ResultLoader(string filename)
        {
            Filename = filename;
        }
        private List<Result> LoadResultsFromFile()
        {
            List<Result> results;
            try
            {
                string fileText = File.ReadAllText(Filename);
                results = JsonSerializer.Deserialize<List<Result>>(fileText) ?? new List<Result>();
            }
            catch (Exception ex)
            {
                results = new List<Result>();
            }
            return results;
        }
        internal void AddResult(Result newResult)
        {
            List<Result> results = LoadResultsFromFile();
            results.Add(newResult);
            SaveResultsToFile(results);
        }
        private void SaveResultsToFile(List<Result> results)
        {
            string objectText = JsonSerializer.Serialize(results);
            File.WriteAllText(Filename, objectText);
        }
        internal void DeleteFile()
        {
            File.Delete(Filename);
        }
    }
    
}
