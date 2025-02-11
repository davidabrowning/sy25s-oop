using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ParProgrammeringStrumpor
{
    internal class SockApp
    {
        private List<Sock> davidsSocks = new List<Sock>();
        private List<Sock> siggesSocks = new List<Sock>();

        public void Run()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            PrintTitle("MENY");
            Console.WriteLine("1. Lägg till en socka");
            Console.WriteLine("2. Spara sockar");
            Console.WriteLine("3. Ladda sockar");
            Console.WriteLine("4. Skriv ut sockar");
            Console.WriteLine("5. Avsluta programmet");
            HandleMenuInput();
        }

        private void PrintTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"===== {title} =====");
        }

        private void HandleMenuInput()
        {
            Console.Write("Ditt val: ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    PrintTitle("Lägg till socka");
                    AddSock();
                    break;
                case "2":
                    PrintTitle("Sparar till fil");
                    Save();
                    break;
                case "3":
                    PrintTitle("Laddar från fil");
                    Load();
                    break;
                case "4":
                    PrintTitle("Visar alla");
                    DisplayAllSocks();
                    break;
                case "5":
                    PrintTitle("Avslutar");
                    Quit();
                    break;
                default:
                    HandleMenuInput();
                    break;
            }
        }

        private void AddSock()
        {
            int size = 0;
            string color = "";
            GradeEnum grade = GradeEnum.None;
            
            // Get size
            while (size < 5 || size > 99)
            {
                Console.Write("Ange storlek (5-99): ");
                int.TryParse(Console.ReadLine(), out size);
            }

            // Get color
            while (color.Length == 0)
            {
                Console.Write("Ange färg: ");
                color = Console.ReadLine().Trim();
            }
            
            // Get grade
            while (grade == GradeEnum.None)
            {
                Console.Write("Ange betyg (1-5 där 1 är bäst): ");
                int.TryParse(Console.ReadLine(), out int gradeInputAsInt);
                if (1 <= gradeInputAsInt && gradeInputAsInt <= 5)
                {
                    grade = (GradeEnum)gradeInputAsInt;
                }
            }

            // Add sock to list
            Sock newSock = new Sock(size, color, grade);
            davidsSocks.Add(newSock);

            ReturnToMenu();
        }

        private void Save()
        {
            Console.WriteLine("Sparar Davids sockar til fil...");

            string sockListJson = JsonSerializer.Serialize(davidsSocks);
            File.WriteAllText("socklista.json", sockListJson);

            Console.WriteLine("Socklistan sparad.");

            ReturnToMenu();
        }

        private void Load()
        {
            Console.WriteLine("Läser in Sigges sockar från fil...");

            try
            {
                string sockListFileText = File.ReadAllText("siggessockar.json");
                siggesSocks = JsonSerializer.Deserialize<List<Sock>>(sockListFileText) ?? new List<Sock>();
                Console.WriteLine("Lyckades läsa in från fil.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lyckades inte läsa in socklistan från filen.");
                Console.WriteLine(ex.Message);
            }


            ReturnToMenu();
        }

        private void DisplayAllSocks()
        {
            Console.WriteLine("Davids sockar:");
            DisplaySockList(davidsSocks);

            Console.WriteLine("Sigges sockar (från fil):");
            DisplaySockList(siggesSocks);

            ReturnToMenu();
        }

        private void DisplaySockList(List<Sock> socks)
        {
            int counter = 1;
            foreach (Sock sock in socks)
            {
                Console.WriteLine($"Par {counter++}. {sock.ToString()}");
            }
        }

        private void Quit()
        {
            Console.WriteLine("Programmet avslutas. Tack och hej då!");
            ConfirmContinue();
        }

        private void ReturnToMenu()
        {
            ConfirmContinue();
            ShowMenu();
        }

        private void ConfirmContinue()
        {
            Console.WriteLine("Tryck ENTER för att fortsätta.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
