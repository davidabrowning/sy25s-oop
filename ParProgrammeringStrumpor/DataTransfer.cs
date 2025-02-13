using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParProgrammeringStrumpor
{
    internal class DataTransfer
    {
        // Constants
        private const string loadFilename = "siggessockar.json";
        private const string saveFilename = "socklista.json";
        private const string UpdateSaveStarted = "Sparar Davids sockor til fil...";
        private const string UpdateSaveSucceeded = "Socklistan sparad.";
        private const string UpdateSaveFailed = "Lyckades inte spara til fil.";
        private const string UpdateLoadStarted = "Läser in Sigges sockor från fil...";
        private const string UpdateLoadSucceeded = "Lyckades läsa in från fil.";
        private const string UpdateLoadFailed = "Lyckades inte läsa in socklistan från filen.";

        // Fields
        private Printer printer;

        // Constructor
        public DataTransfer(Printer printer)
        {
            this.printer = printer;
        }

        public void SaveSockListToFile(List<Sock> socks)
        {
            printer.PrintUpdate(UpdateSaveStarted);
            try
            {
                string sockListJson = JsonSerializer.Serialize(socks);
                File.WriteAllText(saveFilename, sockListJson);
                printer.PrintUpdate(UpdateSaveSucceeded);
            }
            catch (Exception ex)
            {
                printer.PrintUpdate(ex.Message);
                printer.PrintUpdate(UpdateSaveFailed);
            }
        }

        public List<Sock>? LoadSockListFromFile()
        {
            printer.PrintUpdate(UpdateLoadStarted);
            try
            {
                string sockListFileText = File.ReadAllText(loadFilename);
                List<Sock> loadedSocks = JsonSerializer.Deserialize<List<Sock>>(sockListFileText) ?? new List<Sock>();
                printer.PrintUpdate(UpdateLoadSucceeded);
                return loadedSocks;
            }
            catch (Exception ex)
            {
                printer.PrintUpdate(ex.Message);
                printer.PrintUpdate(UpdateLoadFailed);
                return null;
            }
        }
    }
}
