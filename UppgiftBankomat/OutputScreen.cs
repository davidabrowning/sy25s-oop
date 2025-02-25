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

        private void PrintMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\t{text}");
        }
        private void PrintPartialMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"\t{text}");
        }

        public void PrintNeutral(string text) => PrintMessage(text, ConsoleColor.White);
        public void PrintInactive(string text) => PrintMessage(text, ConsoleColor.Gray);
        public void PrintSuccess(string text) => PrintMessage(text, ConsoleColor.Green);
        public void PrintWarning(string text) => PrintMessage(text, ConsoleColor.Red);
        public void PrintPrompt(string text) => PrintPartialMessage(text + " ", ConsoleColor.Cyan);

        public void PrintContinueConfirmation()
        {
            PrintInactive("");
            PrintInactive($"{ConfirmContinue}");
            PrintPartialMessage("", default); // Purpose of this partial message is to indent the cursor location
            Console.ReadLine(); // Purpose of this ReadLine() is to wait for ENTER before continuing
        }
    }
}
