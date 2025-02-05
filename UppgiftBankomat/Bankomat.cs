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
        private const string MenuTitleMain 
            = "Bankomat huvudmeny";
        private const string MenuTitleDeposit
            = "Insättning på ett konto";
        private const string MenuTitleWithdraw 
            = "Uttag på ett konto";
        private const string MenuTitleDisplayOne 
            = "Visa saldot på ett konto";
        private const string MenuTitleDisplayAll 
            = "Lista på alla konton";
        private const string MenuTextDeposit 
            = "Gör en insättning på ett konto";
        private const string MenuTextWithdraw 
            = "Gör ett uttag på ett konto";
        private const string MenuTextDisplayOne 
            = "Visa saldot på ett konto";
        private const string MenuTextDisplayAll 
            = "Skriv ut en lista på alla kontonr och saldon";
        private const string MenuTextQuit 
            = "Avsluta";
        private const string MenuTextGoodbye 
            = "Programmet avslutas. Tack och hej då!";
        private const string PromptYourSelection
            = "Ditt val:";
        private const string PromptAccountNumber 
            = "Ange kontonummer:";
        private const string PromptDepositAmount 
            = "Ange summa att sätta in:";
        private const string PromptWithdrawalAmount 
            = "Ange summa att ta ut:";
        private const string WarningNoAccountsToPrint 
            = "Det finns inga konton att skriva ut.";
        private const string WarningIllegalSelection 
            = "Ogiltigt menyval. Försök igen.";
        private const string WarningIllegalAccountNumber 
            = "Lyckades inte hitta konto med det kontonumret. Försök igen.";

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

        // ============================== METHOD ==============================
        // Start. Starts up the Bankomat, guides the user through the
        // Bankomat's menu, and shuts down the Bankomat.
        // ====================================================================
        public void Start()
        {
            Startup();
            do
            {
                ShowMenuOptions();
                int menuSelection = GetMenuSelection();
                HandleMenuSelection(menuSelection);
            } while (run);
            Shutdown();
        }

        // ============================== METHOD ==============================
        // Startup. Prepares the Console screen for the Bankomat program.
        // ====================================================================
        private void Startup()
        {
            outputScreen.ResetConsoleColor();
            Console.Clear();
        }

        // ============================== METHOD ==============================
        // Shutdown. Prints a goodbye message and resets the Console screen.
        // ====================================================================
        private void Shutdown()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo(MenuTextGoodbye);
            outputScreen.PrintReturnConfirmation();
            outputScreen.ResetConsoleColor();
            Console.Clear();
        }

        // ============================== METHOD ==============================
        // ShowMenuOptions. Prints a list of main menu options for the user to
        // choose from. Does not return anything.
        // ====================================================================
        private void ShowMenuOptions()
        {
            outputScreen.PrintTitle(
                MenuTitleMain);
            outputScreen.PrintInfo(
                $"{(int)MenuOption.Deposit}. {MenuTextDeposit}");
            outputScreen.PrintInfo(
                $"{(int)MenuOption.Withdraw}. {MenuTextWithdraw}");
            outputScreen.PrintInfo(
                $"{(int)MenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            outputScreen.PrintInfo(
                $"{(int)MenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            outputScreen.PrintInfo(
                $"{(int)MenuOption.Quit}. {MenuTextQuit}");
        }

        // ============================== METHOD ==============================
        // GetMenuSelection. Prompts the user to enter an integer menu option.
        // Returns the selected menu option as an int.
        // ====================================================================
        private int GetMenuSelection()
        {
            outputScreen.PrintPrompt(PromptYourSelection);
            return inputKeypad.GetIntInput();
        }

        // ============================== METHOD ==============================
        // HandleMenuSelection. Accepts a menu selection as an int and routes
        // to the appropriate submenu based on what the selection is. Sets
        // bool run to false if the user wants to quit. Prints a warning if the
        // menu selection is an unexpected value. Returns void.
        // ====================================================================
        private void HandleMenuSelection(int menuSelection)
        {
            switch (menuSelection)
            {
                case (int)MenuOption.Deposit:
                    ProcessDeposit();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.Withdraw:
                    ProcessWithdrawal();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.DisplayAccount:
                    DisplayOne();
                    outputScreen.PrintReturnConfirmation();
                    break;
                case (int)MenuOption.DisplayAllAcounts:
                    DisplayAll();
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

        // ============================== METHOD ==============================
        // GetTargetAccountNumber. Asks user to enter an account number
        // and returns the account with the matching account number. Returns
        // null if no matching accounts were found.
        // ====================================================================
        private Account GetTargetAccount()
        {
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            return GetAccountByAccountNumber(accountNumber);
        }

        // ============================== METHOD ==============================
        // ProcessDeposit. Asks the user to enter an account number and deposit
        // amount, then attempts to deposit that amount into the desired
        // account. Returns void.
        // ====================================================================
        private void ProcessDeposit()
        {
            outputScreen.PrintTitle(MenuTitleDeposit);
            Account account = GetTargetAccount();

            // If account is null, print a warning and return to main menu
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

        // ============================== METHOD ==============================
        // ProcessWithdrawal. Asks the user to enter an account number and
        // withdrawal amount, then attempts to withdraw that amount from the
        // desired account. Returns void.
        // ====================================================================
        private void ProcessWithdrawal()
        {
            outputScreen.PrintTitle(MenuTitleWithdraw);
            Account account = GetTargetAccount();

            // If account is null, print a warning and return to main menu
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

        // ============================== METHOD ==============================
        // DisplayOne. Asks for an account number and displays that account.
        // Returns void.
        // ====================================================================
        private void DisplayOne()
        {
            outputScreen.PrintTitle(MenuTitleDisplayOne);
            Account account = GetTargetAccount();

            // If account is null, print a warning and return to main menu
            if (account == null)
            {
                outputScreen.PrintWarning(WarningIllegalAccountNumber);
                return;
            }

            // Display account
            outputScreen.PrintInfo(account.ToString());
        }

        // ============================== METHOD ==============================
        // DisplayAll. Displays a summary of all accounts. Returns void.
        // ====================================================================
        private void DisplayAll()
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

        // ============================== METHOD ==============================
        // GetAccountByAccountNumber. Accepts an int accountNumber and 
        // returns the account with the matching account number. Returns null
        // if no matches are found.
        // ====================================================================
        private Account GetAccountByAccountNumber(int accountNumber)
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

        // ============================== METHOD ==============================
        // RunTests. Static method that runs unit tests for this class.
        // ====================================================================
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
            TestHelper.AssertTrue(title, bankomat.GetAccountByAccountNumber(5) == null);

            title = "GetAccount(11) returns account #5 after 5 accounts have been created";
            bankomat = new Bankomat(5);
            TestHelper.AssertFalse(title, bankomat.GetAccountByAccountNumber(11) == null);
        }
    }
}
