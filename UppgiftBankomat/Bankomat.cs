using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    public class Bankomat
    {
        // Constants
        private const string MenuTitleMain = "Bankomat huvudmeny";
        private const string MenuTitleDeposit = "Insättning på ett konto";
        private const string MenuTitleWithdraw = "Uttag på ett konto";
        private const string MenuTitleDisplayOne = "Visa saldot på ett konto";
        private const string MenuTitleDisplayAll = "Lista på alla konton";
        private const string MenuTextDeposit = "Gör en insättning på ett konto";
        private const string MenuTextWithdraw = "Gör ett uttag på ett konto";
        private const string MenuTextDisplayOne = "Visa saldot på ett konto";
        private const string MenuTextDisplayAll = "Skriv ut en lista på alla kontonr och saldon";
        private const string MenuTextQuit = "Avsluta";
        private const string MenuTextGoodbye = "Programmet avslutas. Tack och hej då!";
        private const string PromptYourSelection = "Ditt val:";
        private const string PromptAccountNumber = "Ange kontonummer:";
        private const string PromptDepositAmount = "Ange summa att sätta in:";
        private const string PromptWithdrawalAmount = "Ange summa att ta ut:";
        private const string WarningNoAccountsToPrint = "Det finns inga konton att skriva ut.";
        private const string WarningIllegalSelection = "Ogiltigt menyval. Försök igen.";
        private const string WarningIllegalAccountNumber = "Lyckades inte hitta konto med det kontonumret. Försök igen.";

        // Fields
        bool run;
        InputKeypad inputKeypad;
        OutputScreen outputScreen;

        // Properties
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
            outputScreen.PrintInfo($"{(int)MenuOption.Deposit}. {MenuTextDeposit}");
            outputScreen.PrintInfo($"{(int)MenuOption.Withdraw}. {MenuTextWithdraw}");
            outputScreen.PrintInfo($"{(int)MenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            outputScreen.PrintInfo($"{(int)MenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            outputScreen.PrintInfo($"{(int)MenuOption.Quit}. {MenuTextQuit}");
        }

        private void GetMenuSelection()
        {
            outputScreen.PrintPrompt(PromptYourSelection);
            switch (inputKeypad.GetIntInput())
            {
                case (int)MenuOption.Deposit:
                    ShowDepositMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.Withdraw:
                    ShowWithdrawalMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.DisplayAccount:
                    ShowDisplayAccountMenu();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.DisplayAllAcounts:
                    DisplayAllAccounts();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.Quit:
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

            // Ask for and deposit desired amount
            outputScreen.PrintPrompt(PromptDepositAmount);
            Decimal amount = inputKeypad.GetDecimalInput();
            Result depositResult = account.Deposit(amount);
            if (depositResult.IsSuccessful) {
                outputScreen.PrintSuccess(String.Format(depositResult.Message));
            }
            else
            {
                outputScreen.PrintWarning(String.Format(depositResult.Message));
            }
        }

        private void ShowWithdrawalMenu()
        {
            outputScreen.PrintTitle(MenuTitleWithdraw);

            // Ask for account number
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            Account account = GetAccount(accountNumber);
            if (account == null)
            {
                outputScreen.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Ask for and withdraw desired amount
            outputScreen.PrintPrompt(PromptWithdrawalAmount);
            Decimal amount = inputKeypad.GetDecimalInput();
            Result withdrawalResult = account.Withdraw(amount);
            if (withdrawalResult.IsSuccessful)
            {
                outputScreen.PrintSuccess(withdrawalResult.Message);
            }
            else
            {
                outputScreen.PrintWarning(withdrawalResult.Message);
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
