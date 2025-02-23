using System.Security.Principal;

namespace UppgiftBankomat
{
    internal class Bankomat
    {
        private const string MenuTitleMain  = "Huvudmeny";
        private const string MenuTitleDeposit = "Insättning på ett konto";
        private const string MenuTitleWithdraw  = "Uttag på ett konto";
        private const string MenuTitleDisplayOne  = "Visa saldot på ett konto";
        private const string MenuTitleDisplayAll  = "Lista på alla konton";
        private const string MenuTitleHello = "Bankomat";
        private const string MenuTitleGoodbye = "Bankomat";
        private const string MenuTextDeposit  = "Gör en insättning på ett konto";
        private const string MenuTextWithdraw  = "Gör ett uttag på ett konto";
        private const string MenuTextDisplayOne  = "Visa saldot på ett konto";
        private const string MenuTextDisplayAll  = "Skriv ut en lista på alla konton";
        private const string MenuTextQuit  = "Avsluta";
        private const string MenuTextHello = "Hej och välkommen till Bankomaten.";
        private const string MenuTextGoodbye  = "Programmet avslutas. Tack och hej då!";
        private const string PromptYourSelection  = "Ditt val:";
        private const string PromptAccountNumber  = "Ange kontonummer:";
        private const string PromptDepositAmount  = "Ange summa i SEK att sätta in:";
        private const string PromptWithdrawalAmount  = "Ange summa i SEK att ta ut:";
        private const string WarningIllegalSelection  = "Ogiltigt menyval. Försök igen.";
        private const string DepositSuccessful = "Insättning lyckades.";
        private const string WithdrawalSuccessful = "Uttagning lyckades.";

        private IInputDevice inputKeypad;
        private IOutputDevice outputScreen;
        private Bank bank;

        public Bankomat(Bank b)
        {
            inputKeypad = new InputKeypad();
            outputScreen = new OutputScreen();
            bank = b;
        }

        public void Go()
        {
            Startup();
            ShowMainMenu();
            Shutdown();
        }

        private void Startup()
        {
            outputScreen.PrintTitle(MenuTitleHello);
            outputScreen.PrintInfo(MenuTextHello);
            outputScreen.PrintContinueConfirmation();
            outputScreen.ResetSettings();
        }

        private void Shutdown()
        {
            outputScreen.PrintTitle(MenuTitleGoodbye);
            outputScreen.PrintInfo(MenuTextGoodbye);
            outputScreen.PrintContinueConfirmation();
            outputScreen.ResetSettings();
        }

        private void ShowMainMenu()
        {
            outputScreen.PrintTitle(MenuTitleMain);
            outputScreen.PrintInfo($"{(int)MenuOption.Deposit}. {MenuTextDeposit}");
            outputScreen.PrintInfo($"{(int)MenuOption.Withdraw}. {MenuTextWithdraw}");
            outputScreen.PrintInfo($"{(int)MenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            outputScreen.PrintInfo($"{(int)MenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            outputScreen.PrintInfo($"{(int)MenuOption.Quit}. {MenuTextQuit}");

            HandleMainMenuSelection();
        }

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

        private void ReturnToMainMenu()
        {
            outputScreen.PrintContinueConfirmation();
            ShowMainMenu();
        }

        private void ShowDepositMenu()
        {
            outputScreen.PrintTitle(MenuTitleDeposit);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            outputScreen.PrintPrompt(PromptDepositAmount);
            decimal amount = inputKeypad.GetDecimalInput();
            outputScreen.PrintInfo(bank.GetAccountSummary(accountNumber));
            MakeDeposit(accountNumber, amount);

            ReturnToMainMenu();
        }

        private void MakeDeposit(int accountNumber, decimal amount)
        {
            try
            {
                bank.Deposit(accountNumber, amount);
                outputScreen.PrintSuccess(String.Format(DepositSuccessful));
                outputScreen.PrintInfo(bank.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputScreen.PrintWarning(e.Message);
            }
        }

        private void ShowWithdrawalMenu()
        {
            outputScreen.PrintTitle(MenuTitleWithdraw);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            outputScreen.PrintPrompt(PromptWithdrawalAmount);
            decimal amount = inputKeypad.GetDecimalInput();
            outputScreen.PrintInfo(bank.GetAccountSummary(accountNumber));
            MakeWithdrawal(accountNumber, amount);

            ReturnToMainMenu();
        }

        private void MakeWithdrawal(int accountNumber, decimal amount)
        {
            try
            {
                bank.Withdraw(accountNumber, amount);
                outputScreen.PrintSuccess(String.Format(WithdrawalSuccessful));
                outputScreen.PrintInfo(bank.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputScreen.PrintWarning(e.Message);
            }
        }

        private void DisplayOne()
        {
            outputScreen.PrintTitle(MenuTitleDisplayOne);
            outputScreen.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputKeypad.GetIntInput();
            try
            {
                outputScreen.PrintInfo(bank.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputScreen.PrintWarning(e.Message);
            }

            ReturnToMainMenu();
        }

        private void DisplayAll()
        {
            outputScreen.PrintTitle(MenuTitleDisplayAll);
            try
            {
                foreach (string accountSummary in bank.GetAllAccountSummaries())
                {
                    outputScreen.PrintInfo(accountSummary);
                }
            }
            catch (Exception e)
            {
                outputScreen.PrintWarning(e.Message);
            }

            ReturnToMainMenu();
        }
    }
}
