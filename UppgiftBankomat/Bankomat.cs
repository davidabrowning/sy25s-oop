using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Bankomat. Machine with a menu where users can interact with bank
    // accounts (deposit, withdraw, display one, and display all).
    // ========================================================================
    internal class Bankomat
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
        private const string MenuTextHello
            = "Hej och välkommen till Bankomaten.";
        private const string MenuTextGoodbye 
            = "Programmet avslutas. Tack och hej då!";
        private const string PromptYourSelection
            = "Ditt val:";
        private const string PromptAccountNumber 
            = "Ange kontonummer:";
        private const string PromptDepositAmount 
            = "Ange summa i SEK att sätta in:";
        private const string PromptWithdrawalAmount 
            = "Ange summa i SEK att ta ut:";
        private const string WarningIllegalSelection 
            = "Ogiltigt menyval. Försök igen.";

        // Fields
        private InputKeypad inputKeypad;
        private OutputScreen outputScreen;
        private Bank bank;

        // Properties

        // Constructor
        public Bankomat(Bank bank)
        {
            this.inputKeypad = new InputKeypad();
            this.outputScreen = new OutputScreen();
            this.bank = bank;
        }

        // ============================== METHOD ==============================
        // Go. Starts up the Bankomat, guides the user through the
        // Bankomat's menu, and shuts down the Bankomat.
        // ====================================================================
        public void Go()
        {
            Startup();
            ShowMainMenu();
            Shutdown();
        }

        // ============================== METHOD ==============================
        // Startup. Prints a hello message and resets the Console screen.
        // ====================================================================
        private void Startup()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo(MenuTextHello);
            outputScreen.PrintContinueConfirmation();
            outputScreen.Reset();
        }

        // ============================== METHOD ==============================
        // Shutdown. Prints a goodbye message and resets the Console screen.
        // ====================================================================
        private void Shutdown()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo(MenuTextGoodbye);
            outputScreen.PrintContinueConfirmation();
            outputScreen.Reset();
        }

        // ============================== METHOD ==============================
        // ShowMainMenu. Prints a list of main menu options for the user to
        // choose from. Continues on to HandleMainMenuSelection.
        // ====================================================================
        private void ShowMainMenu()
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

            HandleMainMenuSelection();
        }

        // ============================== METHOD ==============================
        // HandleMainMenuSelection. Gets a menu selection as an int and routes
        // to the appropriate submenu based on what the selection is. Prints a
        // warning if the menu selection is an unexpected value. Returns void.
        // ====================================================================
        private void HandleMainMenuSelection()
        {
            outputScreen.PrintPrompt(PromptYourSelection);
            int menuSelection = inputKeypad.GetIntInput();

            switch (menuSelection)
            {
                case (int)MenuOption.Deposit:
                    ShowDepositMenu();
                    break;
                case (int)MenuOption.Withdraw:
                    ShowWithdrawalMenu();
                    break;
                case (int)MenuOption.DisplayAccount:
                    DisplayOne();
                    break;
                case (int)MenuOption.DisplayAllAcounts:
                    DisplayAll();
                    break;
                case (int)MenuOption.Quit:
                    break;
                default:
                    outputScreen.PrintWarning(WarningIllegalSelection);
                    ReturnToMainMenu();
                    break;
                }
        }

        // ============================== METHOD ==============================
        // ReturnToMainMenu. Asks user to confirm that they want to continue.
        // Then continues on to ShowMainMenu.
        // ====================================================================
        private void ReturnToMainMenu()
        {
            outputScreen.PrintContinueConfirmation();
            ShowMainMenu();
        }

        // ============================== METHOD ==============================
        // ShowDepositMenu. Asks the user to enter an account number and deposit
        // amount, then attempts to deposit that amount into the desired
        // account. Returns void.
        // ====================================================================
        private void ShowDepositMenu()
        {
            outputScreen.PrintTitle(MenuTitleDeposit);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            outputScreen.PrintPrompt(PromptDepositAmount);
            decimal amount = inputKeypad.GetdecimalInput();
            bank.Deposit(accountNumber, amount, this);

            ReturnToMainMenu();
        }

        // ============================== METHOD ==============================
        // ShowWithdrawalMenu. Asks the user to enter an account number and
        // withdrawal amount, then attempts to withdraw that amount from the
        // desired account. Returns void.
        // ====================================================================
        private void ShowWithdrawalMenu()
        {
            outputScreen.PrintTitle(MenuTitleWithdraw);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            outputScreen.PrintPrompt(PromptWithdrawalAmount);
            decimal amount = inputKeypad.GetdecimalInput();
            bank.Withdraw(accountNumber, amount, this);

            ReturnToMainMenu();
        }

        // ============================== METHOD ==============================
        // DisplayOne. Asks for an account number and displays that account.
        // Returns void.
        // ====================================================================
        private void DisplayOne()
        {
            outputScreen.PrintTitle(MenuTitleDisplayOne);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            bank.DisplayAccount(accountNumber, this);

            ReturnToMainMenu();
        }

        // ============================== METHOD ==============================
        // DisplayAll. Displays a summary of all accounts. Returns void.
        // ====================================================================
        private void DisplayAll()
        {
            outputScreen.PrintTitle(MenuTitleDisplayAll);
            bank.DisplayAllAccounts(this);

            ReturnToMainMenu();
        }


        // ============================== METHOD ==============================
        // ShowInfo. Prints an informational message.
        // ====================================================================
        public void ShowInfo(string message)
        {
            outputScreen.PrintInfo(message);
        }

        // ============================== METHOD ==============================
        // ShowSuccess. Prints a successful message.
        // ====================================================================
        public void ShowSuccess(string message)
        {
            outputScreen.PrintSuccess(message);
        }

        // ============================== METHOD ==============================
        // ShowError. Prints an error message.
        // ====================================================================
        public void ShowError(string message)
        {
            outputScreen.PrintWarning(message);
        }
    }
}
