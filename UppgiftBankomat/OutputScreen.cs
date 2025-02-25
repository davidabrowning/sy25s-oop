namespace UppgiftBankomat
{
    internal class OutputScreen : IOutputDevice
    {
        private const int TitleHeadingWidth = 40;
        private const string TitleBorder = "#";
        private const string TitleSpacer = " ";
        private const string ConfirmContinue = "Tryck ENTER för att fortsätta.";

        public void ResetSettings()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            PrintTitleBorder();
            PrintTitleSpacerLeft(title);
            Console.Write(title);
            PrintTitleSpacerRight(title);
            PrintTitleBorder();
        }

        private void PrintTitleBorder()
        {
            Console.Write("\n\t");
            for (int i = 0; i < TitleHeadingWidth; i++)
                Console.Write(TitleBorder);
            Console.WriteLine();
        }

        private void PrintTitleSpacerLeft(string title)
        {
            Console.Write($"\t##");
            for (int i = 0; i < (TitleHeadingWidth - title.Length - 4) / 2; i++)
                Console.Write(TitleSpacer);
        }

        private void PrintTitleSpacerRight(string title)
        {
            for (int i = 0; i < (TitleHeadingWidth - title.Length - 3) / 2; i++)
                Console.Write(TitleSpacer);
            Console.Write("##");
        }

        public void PrintNeutral(string info)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t{info}");
        }

        public void PrintSuccess(string success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t{success}");
        }

        public void PrintWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{warning}");
        }

        public void PrintPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\t{prompt} ");
        }

        public void PrintContinueConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\t{ConfirmContinue}");
            Console.Write("\n\t");
            Console.ReadLine(); // Purpose of this ReadLine() is to wait for ENTER before continuing
        }
    }
}
