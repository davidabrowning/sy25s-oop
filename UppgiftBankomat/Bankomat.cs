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
        // Constants
        private const string WarningNoAccountsToPrint = "Det finns inga konton att skriva ut.";

        // Private variables
        Menu menu;

        // Public properties
        internal Account[] Accounts { get; private set; }

        // Constructors
        public Bankomat() : this(0) { }
        public Bankomat(int accountsToCreate)
        {
            menu = new Menu();
            Accounts = new Account[accountsToCreate];
            for (int i = 0; i < Accounts.Length; i++)
            {
                Accounts[i] = new Account();
            }
        }

        // Methods
        public void Start()
        {
            do
            {
                ShowMainMenu();
            } while (menu.Run);
        }

        private void ShowMainMenu()
        {
            menu.ShowMainMenu();
            switch (menu.GetMenuSelectionAsInt("Ditt val:"))
            {
                case Menu.OptionDeposit:
                    ShowDepositMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case Menu.OptionWithdraw:
                    ShowWithdrawalMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case Menu.OptionDisplayAccount:
                    ShowDisplayAccountMenu();
                    Printer.PrintReturnConfirmation();
                    break;
                case Menu.OptionDisplayAllAccounts:
                    DisplayAllAccounts();
                    Printer.PrintReturnConfirmation();
                    break;
                case Menu.OptionQuit:
                    menu.Run = false;
                    break;
                default:
                    Printer.PrintWarning("Ogiltigt menyval. Försök igen.");
                    Printer.PrintReturnConfirmation();
                    break;
                }
        }

        private void ShowDepositMenu()
        {
            Printer.PrintTitle(Menu.TitleDeposit);

            // Collect and validate account number
            int accountNumber = menu.GetMenuSelectionAsInt("Ange kontonummer:");
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning("Lyckades inte hitta konto med det kontonumret. Försök igen.");
                return;
            }

            // Collect and validate amount to deposit
            Decimal amount = menu.GetMenuSelectionAsDecimal("Ange summa att sätta in:");
            if (amount == (Decimal)0)
            {
                Printer.PrintWarning("Ogiltig inmatning av summa at sätta in. Försök igen.");
                return;
            }

            // Deposit said amount
            account.Deposit(amount);
        }

        private void ShowWithdrawalMenu()
        {
            Printer.PrintTitle(Menu.TitleWithdraw);

            // Collect and validate account number
            int accountNumber = menu.GetMenuSelectionAsInt("Ange kontonummer:");
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning("Lyckades inte hitta konto med det kontonumret. Försök igen.");
                return;
            }

            // Collect and validate amount to withdraw
            Decimal amount = menu.GetMenuSelectionAsDecimal("Ange summa att ta ut:");
            if (amount == (Decimal)0)
            {
                Printer.PrintWarning("Ogiltig inmatning av summa at ta ut. Försök igen.");
                return;
            }

            // Withdraw said amount
            account.Withdraw(amount);
        }

        private void ShowDisplayAccountMenu()
        {
            Printer.PrintTitle(Menu.TitleDisplayAccount);

            // Collect and validate account number
            int accountNumber = menu.GetMenuSelectionAsInt("Ange kontonummer:");
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                Printer.PrintWarning("Lyckades inte hitta konto med det kontonumret. Försök igen.");
                return;
            }

            // Display account
            Printer.PrintInfo(account.ToString());
        }

        private void DisplayAllAccounts()
        {
            Printer.PrintTitle(Menu.TitleDisplayAllAccounts);
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
