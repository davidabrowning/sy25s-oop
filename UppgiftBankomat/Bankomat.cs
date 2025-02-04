using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UppgiftBankomat
{
    public class Bankomat
    {
        // Menu text
        private string MenuTitleMain = "Bankomat huvudmeny";
        private string MenuTitleDeposit = "Insättning på ett konto";
        private string MenuTitleWithdraw = "Uttag på ett konto";
        private string MenuTitleDisplayOne = "Visa saldot på ett konto";
        private string MenuTitleDisplayAll = "Lista på alla konton";
        private string MenuTextDeposit = "Gör en insättning på ett konto";
        private string MenuTextWithdraw = "Gör ett uttag på ett konto";
        private string MenuTextDisplayOne = "Visa saldot på ett konto";
        private string MenuTextDisplayAll = "Skriv ut en lista på alla kontonr och saldon";
        private string MenuTextQuit = "Avsluta";
        private string MenuTextGoodbye = "Programmet avslutas. Tack och hej då!";
        private string PromptYourSelection = "Ditt val:";
        private string PromptAccountNumber = "Ange kontonummer:";
        private string PromptDepositAmount = "Ange summa att sätta in:";
        private string PromptWithdrawalAmount = "Ange summa att ta ut:";
        private string WarningNoAccountsToPrint = "Det finns inga konton att skriva ut.";
        private string WarningIllegalSelection = "Ogiltigt menyval. Försök igen.";
        private string WarningIllegalAccountNumber = "Lyckades inte hitta konto med det kontonumret. Försök igen.";
        private string WarningIllegalDepositAmount = "Ogiltig inmatning av summa at sätta in. Försök igen.";
        private string WarningIllegalWithdrawalAmount = "Ogiltig inmatning av summa at ta ut. Försök igen.";

        // Private variables
        bool run;
        UserInputRetriever userInputRetriever;

        // Public properties
        internal Account[] Accounts { get; private set; }

        // Constructors
        public Bankomat() : this(0) { }
        public Bankomat(int accountsToCreate)
        {
            run = true;
            userInputRetriever = new UserInputRetriever();
            Accounts = new Account[accountsToCreate];
            for (int i = 0; i < Accounts.Length; i++)
            {
                Accounts[i] = new Account();
            }
        }

        // Methods
        public void Start()
        {
            Startup();
            do
            {
                ShowMenuOptions();
                HandleMenuSelection();
            } while (run);
            Shutdown();
        }

        private void Startup()
        {
            Printer.ResetConsoleColor();
            Console.Clear();
        }

        private void ShowMenuOptions()
        {
            Printer.PrintTitle(MenuTitleMain);
            Printer.PrintInfo($"{(int)MainMenuOption.Deposit}. {MenuTextDeposit}");
            Printer.PrintInfo($"{(int)MainMenuOption.Withdraw}. {MenuTextWithdraw}");
            Printer.PrintInfo($"{(int)MainMenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            Printer.PrintInfo($"{(int)MainMenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            Printer.PrintInfo($"{(int)MainMenuOption.Quit}. {MenuTextQuit}");
        }

        private void HandleMenuSelection()
        {
            switch (userInputRetriever.GetIntInput(PromptYourSelection))
            {
                case (int)MainMenuOption.Deposit:
                    ShowDepositMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.Withdraw:
                    ShowWithdrawalMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.DisplayAccount:
                    ShowDisplayAccountMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.DisplayAllAcounts:
                    DisplayAllAccounts();
                    Printer.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.Quit:
                    run = false;
                    break;
                default:
                    Printer.PrintWarning(WarningIllegalSelection);
                    Printer.PrintReturnConfirmation();
                    break;
                }
        }

        private void ShowDepositMenu()
        {
            Printer.PrintTitle(MenuTitleDeposit);

            // Collect and validate account number
            int accountNumber = userInputRetriever.GetIntInput(PromptAccountNumber);
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Collect and validate amount to deposit
            Decimal amount = userInputRetriever.GetDecimalInput(PromptDepositAmount);
            if (amount == (Decimal)0)
            {
                Printer.PrintWarning(WarningIllegalDepositAmount);
                return;
            }

            // Deposit said amount
            account.Deposit(amount);
        }

        private void ShowWithdrawalMenu()
        {
            Printer.PrintTitle(MenuTitleWithdraw);

            // Collect and validate account number
            int accountNumber = userInputRetriever.GetIntInput(PromptAccountNumber);
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Collect and validate amount to withdraw
            Decimal amount = userInputRetriever.GetDecimalInput(PromptWithdrawalAmount);
            if (amount == (Decimal)0)
            {
                Printer.PrintWarning(WarningIllegalWithdrawalAmount);
                return;
            }

            // Withdraw said amount
            account.Withdraw(amount);
        }

        private void ShowDisplayAccountMenu()
        {
            Printer.PrintTitle(MenuTitleDisplayOne);

            // Collect and validate account number
            int accountNumber = userInputRetriever.GetIntInput(PromptAccountNumber);
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Display account
            Printer.PrintInfo(account.ToString());
        }

        private void DisplayAllAccounts()
        {
            Printer.PrintTitle(MenuTitleDisplayAll);
            if (Accounts.Length == 0)
            {
                Printer.PrintWarning(WarningNoAccountsToPrint);
                return;
            }
            foreach (Account account in Accounts)
            {
                Printer.PrintInfo(account.ToString());
            }
        }

        private void Shutdown()
        {
            Printer.PrintTitle(MenuTitleMain);
            Printer.PrintInfo(MenuTextGoodbye);
            Printer.PrintReturnConfirmation();
            Printer.ResetConsoleColor();
            Console.Clear();
        }

        private Account GetAccount(int accountNumber)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        internal static void RunTests()
        {
            // Variables to reuse during testing
            Bankomat bankomat;
            string title;

            Printer.PrintSubtitle("Kör tester på Bankomat-klassen.");

            title = "Bankomat skapad med 10 konton innehåller 10 konton";
            bankomat = new Bankomat(10);
            TestHelper.AssertEquals(title, 10, bankomat.Accounts.Length);

            title = "GetAccount(11) initially returns null";
            bankomat = new Bankomat();
            TestHelper.AssertTrue(title, bankomat.GetAccount(5) == null);

            title = "GetAccount(11) returns account #5 after 5 accounts have been created";
            bankomat = new Bankomat(5);
            TestHelper.AssertFalse(title, bankomat.GetAccount(11) == null);
        }
    }
}
