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
        private string SuccessDeposit = "Du har satt in {0} på konto #{1}. Nuvarande saldo är {2}.";
        private string SuccessWithdrawal = "Du har tagit ut {0}. Nuvarande saldo är {1}.";
        private string WarningNoAccountsToPrint = "Det finns inga konton att skriva ut.";
        private string WarningIllegalSelection = "Ogiltigt menyval. Försök igen.";
        private string WarningIllegalAccountNumber = "Lyckades inte hitta konto med det kontonumret. Försök igen.";
        private string WarningIllegalDepositAmount = "Ogiltig inmatning av summa at sätta in. Försök igen.";
        private string WarningIllegalWithdrawalAmount = "Ogiltig inmatning av summa at ta ut. Försök igen.";
        private string WarningDepositFailure = "Lyckades inte sätta in {0}. Nuvarande saldo är {1}. Försök igen.";
        private string WarningWithdrawalFailure = "Lyckades inte ta ut {0}. Nuvarande saldo är {1}. Försök igen.";

        // Private variables
        bool run;
        InputKeypad inputKeypad;
        OutputScreen outputScreen;

        // Public properties
        internal Account[] Accounts { get; private set; }

        // Constructors
        public Bankomat() : this(0) { }
        public Bankomat(int accountsToCreate)
        {
            run = true;
            inputKeypad = new InputKeypad();
            outputScreen = new OutputScreen();
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
                GetMenuSelection();
            } while (run);
            Shutdown();
        }

        private void Startup()
        {
            outputScreen.ResetConsoleColor();
            Console.Clear();
        }

        private void ShowMenuOptions()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo($"{(int)MainMenuOption.Deposit}. {MenuTextDeposit}");
            outputScreen.PrintInfo($"{(int)MainMenuOption.Withdraw}. {MenuTextWithdraw}");
            outputScreen.PrintInfo($"{(int)MainMenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            outputScreen.PrintInfo($"{(int)MainMenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            outputScreen.PrintInfo($"{(int)MainMenuOption.Quit}. {MenuTextQuit}");
        }

        private void GetMenuSelection()
        {
            outputScreen.PrintPrompt(PromptYourSelection);
            switch (inputKeypad.GetIntInput())
            {
                case (int)MainMenuOption.Deposit:
                    ShowDepositMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.Withdraw:
                    ShowWithdrawalMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.DisplayAccount:
                    ShowDisplayAccountMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.DisplayAllAcounts:
                    DisplayAllAccounts();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MainMenuOption.Quit:
                    run = false;
                    break;
                default:
                    outputScreen.PrintWarning(WarningIllegalSelection);
                    outputScreen.PrintReturnConfirmation();
                    break;
                }
        }

        private void ShowDepositMenu()
        {
            outputScreen.PrintTitle(MenuTitleDeposit);

            // Collect and validate account number
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                outputScreen.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Collect and validate amount to deposit
            outputScreen.PrintPrompt(PromptDepositAmount);
            Decimal amount = inputKeypad.GetDecimalInput();
            if (amount == (Decimal)0)
            {
                outputScreen.PrintWarning(WarningIllegalDepositAmount);
                return;
            }

            // Deposit said amount
            bool depositSuccessful = account.Deposit(amount);
            if (depositSuccessful) {
                outputScreen.PrintSuccess(String.Format(SuccessDeposit, amount, account.AccountNumber, account.Balance));
            }
            else
            {
                outputScreen.PrintWarning(String.Format(WarningWithdrawalFailure, amount, account.Balance));
            }
        }

        private void ShowWithdrawalMenu()
        {
            outputScreen.PrintTitle(MenuTitleWithdraw);

            // Collect and validate account number
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                outputScreen.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Collect and validate amount to withdraw
            outputScreen.PrintPrompt(PromptWithdrawalAmount);
            Decimal amount = inputKeypad.GetDecimalInput();
            if (amount == (Decimal)0)
            {
                outputScreen.PrintWarning(WarningIllegalWithdrawalAmount);
                return;
            }

            // Withdraw said amount
            bool withdrawalSuccessful = account.Withdraw(amount);
            if (withdrawalSuccessful)
            {
                outputScreen.PrintSuccess(String.Format(SuccessWithdrawal, amount, account.Balance));
            }
            else
            {
                outputScreen.PrintWarning(String.Format(WarningWithdrawalFailure, amount, account.Balance));
            }
        }

        private void ShowDisplayAccountMenu()
        {
            outputScreen.PrintTitle(MenuTitleDisplayOne);

            // Collect and validate account number
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                outputScreen.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Display account
            outputScreen.PrintInfo(account.ToString());
        }

        private void DisplayAllAccounts()
        {
            outputScreen.PrintTitle(MenuTitleDisplayAll);
            if (Accounts.Length == 0)
            {
                outputScreen.PrintWarning(WarningNoAccountsToPrint);
                return;
            }
            foreach (Account account in Accounts)
            {
                outputScreen.PrintInfo(account.ToString());
            }
        }

        private void Shutdown()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo(MenuTextGoodbye);
            outputScreen.PrintReturnConfirmation();
            outputScreen.ResetConsoleColor();
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

            Console.WriteLine("Kör tester på Bankomat-klassen.");

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
