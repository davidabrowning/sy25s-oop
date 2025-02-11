using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Drawing;
using System.Diagnostics;

namespace ParProgrammeringStrumpor
{
    internal class SockApp
    {
        // Constants
        private const string MenuTitle = "Meny";
        private const string MenuPrompt = "Ditt val";
        private readonly string[] MenuOptions =
        {
            $"{(int)MainMenu.AddSock}. Lägg till en socka",
            $"{(int)MainMenu.SaveSocks}. Spara sockar",
            $"{(int)MainMenu.LoadFromFile}. Ladda sockar",
            $"{(int)MainMenu.DisplayAll}. Skriv ut sockar",
            $"{(int)MainMenu.Quit}. Avsluta programmet"
        };
        private const string AddTitle = "Lägg till socka";
        private const string SaveTitle = "Sparar till fil";
        private const string LoadTitle = "Laddar från fil";
        private const string DisplayAllTitle = "Visar alla";
        private const string QuitTitle = "Avslutar";
        private const string EnterToContinue = "Tryck ENTER för att fortsätta.";
        private const string SizePrompt = "Ange storlek (5-99)";
        private const string ColorPrompt = "Ange färg";
        private const string GradePrompt = "Ange betyg (1-5 där 1 är bäst)";
        private const string AddSockSucceeded = "Lyckades lägga till ny socka.";
        private const string UpdateSaveStarted = "Sparar Davids sockar til fil...";
        private const string UpdateSaveSucceeded = "Socklistan sparad.";
        private const string UpdateSaveFailed = "Lyckades inte spara til fil.";
        private const string UpdateLoadStarted = "Läser in Sigges sockar från fil...";
        private const string UpdateLoadSucceeded = "Lyckades läsa in från fil.";
        private const string UpdateLoadFailed = "Lyckades inte läsa in socklistan från filen.";
        private const string QuitMessage = "Programmet avslutas. Tack och hej då!";

        // Private fields
        private Printer printer = new Printer();
        private List<Sock> davidsSocks = new List<Sock>();
        private List<Sock> siggesSocks = new List<Sock>();

        public void Run()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            printer.PrintTitle(MenuTitle);
            printer.PrintArray(MenuOptions);
            HandleMenuInput();
        }

        private void HandleMenuInput()
        {
            printer.PrintPrompt(MenuPrompt);
            string menuSelectionString = Console.ReadLine().Trim();
            int.TryParse(menuSelectionString, out int menuSelectionInt);
            switch ((MainMenu) menuSelectionInt)
            {
                case MainMenu.AddSock:
                    AddSock();
                    break;
                case MainMenu.SaveSocks:
                    Save();
                    break;
                case MainMenu.LoadFromFile:
                    Load();
                    break;
                case MainMenu.DisplayAll:
                    DisplayAllSocks();
                    break;
                case MainMenu.Quit:
                    Quit();
                    break;
                default:
                    HandleMenuInput();
                    break;
            }
        }

        private void AddSock()
        {
            printer.PrintTitle(AddTitle);

            // Create sock
            int size = GetSockSize();
            string color = GetSockColor();
            GradeEnum grade = GetSockGrade();
            Sock newSock = new Sock(size, color, grade);

            // Add sock to list
            davidsSocks.Add(newSock);
            printer.PrintUpdate(AddSockSucceeded);

            ReturnToMenu();
        }

        private int GetSockSize()
        {
            int size = 0;
            while (size < Sock.MinSize || size > Sock.MaxSize)
            {
                printer.PrintPrompt(SizePrompt);
                int.TryParse(Console.ReadLine(), out size);
            }
            return size;
        }

        private string GetSockColor()
        {
            string color = "";
            while (color.Length == 0)
            {
                printer.PrintPrompt(ColorPrompt);
                color = Console.ReadLine().Trim();
            }
            return color;
        }

        private GradeEnum GetSockGrade()
        {
            GradeEnum grade = GradeEnum.None;
            while (grade == GradeEnum.None)
            {
                printer.PrintPrompt(GradePrompt);
                int.TryParse(Console.ReadLine(), out int gradeInputAsInt);
                if (1 <= gradeInputAsInt && gradeInputAsInt <= 5)
                {
                    grade = (GradeEnum)gradeInputAsInt;
                }
            }
            return grade;
        }

        private void Save()
        {
            printer.PrintTitle(SaveTitle);
            printer.PrintUpdate(UpdateSaveStarted);

            try
            {
                string sockListJson = JsonSerializer.Serialize(davidsSocks);
                File.WriteAllText("socklista.json", sockListJson);
                printer.PrintUpdate(UpdateSaveSucceeded);
            }
            catch (Exception ex)
            {
                printer.PrintUpdate(UpdateSaveFailed);
                printer.PrintUpdate(ex.Message);
            }

            ReturnToMenu();
        }

        private void Load()
        {
            printer.PrintTitle(LoadTitle);
            printer.PrintUpdate(UpdateLoadStarted);

            try
            {
                string sockListFileText = File.ReadAllText("siggessockar.json");
                siggesSocks = JsonSerializer.Deserialize<List<Sock>>(sockListFileText) ?? new List<Sock>();
                printer.PrintUpdate(UpdateLoadSucceeded);
            }
            catch (Exception ex)
            {
                printer.PrintUpdate(UpdateLoadFailed);
                printer.PrintUpdate(ex.Message);
            }

            ReturnToMenu();
        }

        private void DisplayAllSocks()
        {
            printer.PrintTitle(DisplayAllTitle);
            DisplaySockList("Davids sockar", davidsSocks);
            DisplaySockList("Sigges sockar (från fil)", siggesSocks);
            ReturnToMenu();
        }

        private void DisplaySockList(string sockListName, List<Sock> socks)
        {
            printer.PrintSubtitle(sockListName);
            int counter = 1;
            foreach (Sock sock in socks)
            {
                Console.WriteLine($"Par {counter++}. {sock.ToString()}");
            }
        }

        private void Quit()
        {
            printer.PrintTitle(QuitTitle);
            printer.PrintUpdate(QuitMessage);
            printer.ConfirmContinue(EnterToContinue);
        }

        private void ReturnToMenu()
        {
            printer.ConfirmContinue(EnterToContinue);
            ShowMenu();
        }
    }
}
