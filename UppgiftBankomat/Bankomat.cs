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
        private const string WithdrawalSuccessful = "Uttag lyckades.";

        private IInputDevice inputDevice;
        private IOutputDevice outputDevice;
        private IAccountRepository accountRepository;

        public Bankomat(IAccountRepository accountRepository)
        {
            this.inputDevice = new InputKeypad();
            this.outputDevice = new OutputScreen();
            this.accountRepository = accountRepository;
        }

        public void Go()
        {
            Startup();
            ShowMainMenu();
            Shutdown();
        }

        private void Startup()
        {
            outputDevice.PrintTitle(MenuTitleHello);
            outputDevice.PrintNeutral(MenuTextHello);
            outputDevice.PrintContinueConfirmation();
            outputDevice.ResetSettings();
        }

        private void Shutdown()
        {
            outputDevice.PrintTitle(MenuTitleGoodbye);
            outputDevice.PrintNeutral(MenuTextGoodbye);
            outputDevice.PrintContinueConfirmation();
            outputDevice.ResetSettings();
        }

        private void ShowMainMenu()
        {
            outputDevice.PrintTitle(MenuTitleMain);
            outputDevice.PrintNeutral($"{(int)MenuOption.Deposit}. {MenuTextDeposit}");
            outputDevice.PrintNeutral($"{(int)MenuOption.Withdraw}. {MenuTextWithdraw}");
            outputDevice.PrintNeutral($"{(int)MenuOption.DisplayAccount}. {MenuTextDisplayOne}");
            outputDevice.PrintNeutral($"{(int)MenuOption.DisplayAllAcounts}. {MenuTextDisplayAll}");
            outputDevice.PrintNeutral($"{(int)MenuOption.Quit}. {MenuTextQuit}");

            HandleMainMenuSelection();
        }

        private void HandleMainMenuSelection()
        {
            outputDevice.PrintPrompt(PromptYourSelection);
            int menuSelection = inputDevice.GetIntInput();

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
                    outputDevice.PrintWarning(WarningIllegalSelection);
                    ReturnToMainMenu();
                    break;
                }
        }

        private void ReturnToMainMenu()
        {
            outputDevice.PrintContinueConfirmation();
            ShowMainMenu();
        }

        private void ShowDepositMenu()
        {
            outputDevice.PrintTitle(MenuTitleDeposit);
            outputDevice.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputDevice.GetIntInput();
            outputDevice.PrintPrompt(PromptDepositAmount);
            decimal amount = inputDevice.GetDecimalInput();
            MakeDeposit(accountNumber, amount);

            ReturnToMainMenu();
        }

        private void MakeDeposit(int accountNumber, decimal amount)
        {
            try
            {
                outputDevice.PrintNeutral(accountRepository.GetAccountSummary(accountNumber));
                accountRepository.Deposit(accountNumber, amount);
                outputDevice.PrintSuccess(String.Format(DepositSuccessful));
                outputDevice.PrintNeutral(accountRepository.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputDevice.PrintWarning(e.Message);
            }
        }

        private void ShowWithdrawalMenu()
        {
            outputDevice.PrintTitle(MenuTitleWithdraw);
            outputDevice.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputDevice.GetIntInput();
            outputDevice.PrintPrompt(PromptWithdrawalAmount);
            decimal amount = inputDevice.GetDecimalInput();
            MakeWithdrawal(accountNumber, amount);

            ReturnToMainMenu();
        }

        private void MakeWithdrawal(int accountNumber, decimal amount)
        {
            try
            {
                outputDevice.PrintNeutral(accountRepository.GetAccountSummary(accountNumber));
                accountRepository.Withdraw(accountNumber, amount);
                outputDevice.PrintSuccess(String.Format(WithdrawalSuccessful));
                outputDevice.PrintNeutral(accountRepository.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputDevice.PrintWarning(e.Message);
            }
        }

        private void DisplayOne()
        {
            outputDevice.PrintTitle(MenuTitleDisplayOne);
            outputDevice.PrintPrompt(PromptAccountNumber);
            int accountNumber = inputDevice.GetIntInput();
            try
            {
                outputDevice.PrintNeutral(accountRepository.GetAccountSummary(accountNumber));
            }
            catch (Exception e)
            {
                outputDevice.PrintWarning(e.Message);
            }

            ReturnToMainMenu();
        }

        private void DisplayAll()
        {
            outputDevice.PrintTitle(MenuTitleDisplayAll);
            try
            {
                foreach (string accountSummary in accountRepository.GetAllAccountSummaries())
                    outputDevice.PrintNeutral(accountSummary);
            }
            catch (Exception e)
            {
                outputDevice.PrintWarning(e.Message);
            }

            ReturnToMainMenu();
        }
    }
}
