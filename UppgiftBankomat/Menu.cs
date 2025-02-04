using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class Menu
    {
        // Static menu text
        internal const string TitleMain = "Bankomat huvudmeny";
        internal const string TitleDeposit = "Insättning på ett konto";
        internal const string TitleWithdraw = "Uttag på ett konto";
        internal const string TitleDisplayAccount = "Visa saldot på ett konto";
        internal const string TitleDisplayAllAccounts = "Lista på alla konton";
        private static string OptionDepositText = $"{OptionDeposit}. Gör en insättning på ett konto";
        private static string OptionWithdrawText = $"{OptionWithdraw}. Gör ett uttag på ett konto";
        private static string OptionDisplayAccountText = $"{OptionDisplayAccount}. Visa saldot på ett konto";
        private static string OptionDisplayAllAccountsText = $"{OptionDisplayAllAccounts}. Skriv ut en lista på alla kontonr och saldon";
        private static string OptionQuitText = $"{OptionQuit}. Quit";

        // Menu options
        internal const int OptionDeposit = 1;
        internal const int OptionWithdraw = 2;
        internal const int OptionDisplayAccount = 3;
        internal const int OptionDisplayAllAccounts = 4;
        internal const int OptionQuit = 5;

        // Public properties
        internal bool Run { get; set; }

        // Constructors
        internal Menu()
        {
            Run = true;
        }

        internal void ShowMainMenu()
        {
            Printer.PrintTitle(TitleMain);
            Printer.PrintInfo(OptionDepositText);
            Printer.PrintInfo(OptionWithdrawText);
            Printer.PrintInfo(OptionDisplayAccountText);
            Printer.PrintInfo(OptionDisplayAllAccountsText);
            Printer.PrintInfo(OptionQuitText);
        }
        internal int GetMenuSelectionAsInt(string prompt)
        {
            Printer.PrintPrompt(prompt);
            Int32.TryParse(Console.ReadLine().Trim(), out int menuSelection);
            return menuSelection;
        }
        internal Decimal GetMenuSelectionAsDecimal(string prompt)
        {
            Printer.PrintPrompt(prompt);
            Decimal.TryParse(Console.ReadLine().Trim(), out Decimal menuSelection);
            return menuSelection;
        }
    }
}
