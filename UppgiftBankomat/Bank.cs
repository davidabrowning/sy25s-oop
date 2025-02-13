using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Bank. Contains accounts and makes changes to those accounts (create,
    // deposit, withdraw).
    // ========================================================================
    internal class Bank
    {
        // Constants
        private const decimal minBalance = 0.00M;
        private const decimal minDeposit = 0.01M;
        private const decimal minWithdrawal = 0.01M;
        private const string WarningIllegalAccountNumber 
            = "Lyckades inte hitta detta konto.";
        private const string DepositSuccessful 
            = "Du har satt in {0} på konto #{1}.";
        private const string WarningDepositMustBeGreaterThanMinDeposit 
            = "Insättning måste vara minst {0}.";
        private const string WithdrawalSuccessful 
            = "Du har tagit ut {0} från konto #{1}.";
        private const string WarningWithdrawalMustBeGreaterThanMinWithdrawal 
            = "Summa måsta vara minst {0}.";
        private const string WarningBalanceCannotBeLowerThanMinimum 
            = "Saldo får inte bli mindre än {0}.";
        private const string WarningNoAccountsToPrint 
            = "Lyckades inte hitta några konton.";

        // Properties
        public Account[]? Accounts { get; private set; }

        // ============================== METHOD ==============================
        // CreateAccounts. Creates the specified number of new blank accounts.
        // ====================================================================
        public void CreateAccounts(int accountsToCreate)
        {
            Accounts = new Account[accountsToCreate];
            for (int i = 0; i < Accounts.Length; i++)
            {
                Accounts[i] = new Account();
            }
        }

        // ============================== METHOD ==============================
        // GetAccountByAccountNumber. Returns the account with the desired
        // account number, or null if no matches found.
        // ====================================================================
        public Account? GetAccountByAccountNumber(int accountNumber, Bankomat bankomat)
        {
            if (Accounts == null)
            {
                bankomat.ShowError(WarningNoAccountsToPrint);
                return null;
            }
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            bankomat.ShowError(WarningIllegalAccountNumber);
            return null;
        }

        // ============================== METHOD ==============================
        // IsValidDeposit. Checks if the deposit amount is valid. Prints out a
        // relevant message to the user.
        // ====================================================================
        private bool IsValidDeposit(
            Account account, decimal amount, Bankomat bankomat)
        {
            if (amount < minDeposit)
            {
                bankomat.ShowError(String.Format(
                    WarningDepositMustBeGreaterThanMinDeposit,
                    minDeposit.ToString(account.CurrencyFormat)));
                return false;
            }
            if (account.Balance + amount < minBalance)
            {
                bankomat.ShowError(String.Format(
                    WarningBalanceCannotBeLowerThanMinimum,
                    minBalance));
                return false;
            }
            return true;
        }

        // ============================== METHOD ==============================
        // IsValidWithdrawal. Checks if the withdrawal amount is valid. Prints
        // out a relevant message to the user.
        // ====================================================================
        private bool IsValidWithdrawal(
            Account account, decimal amount, Bankomat bankomat)
        {
            if (amount < minWithdrawal)
            {
                bankomat.ShowError(String.Format(
                    WarningWithdrawalMustBeGreaterThanMinWithdrawal,
                    minWithdrawal.ToString(account.CurrencyFormat)));
                return false;
            }
            if (account.Balance - amount < minBalance)
            {
                bankomat.ShowError(String.Format(
                    WarningBalanceCannotBeLowerThanMinimum,
                    minBalance.ToString(account.CurrencyFormat)));
                return false;
            }
            return true;
        }

        // ============================== METHOD ==============================
        // Deposit. Deposits the fund amount in the account. Prints out a
        // relevant message to the user.
        // ====================================================================
        public void Deposit(int accountNum, decimal amount, Bankomat bankomat)
        {
            Account? account = GetAccountByAccountNumber(accountNum, bankomat);
            if (account == null)
            {
                return;
            }
            bankomat.ShowInfo(account.ToString());
            if (IsValidDeposit(account, amount, bankomat))
            { 
                account.AddFunds(amount);
                bankomat.ShowSuccess(String.Format(
                    DepositSuccessful,
                    amount.ToString(account.CurrencyFormat),
                    account.FormattedAccountNumber));
                bankomat.ShowInfo(account.ToString());
            }
        }

        // ============================== METHOD ==============================
        // Withdraw. Withdraws the fund amount from the account. Prints out a
        // relevant message to the user.
        // ====================================================================
        public void Withdraw(int accountNum, decimal amount, Bankomat bankomat)
        {
            Account? account = GetAccountByAccountNumber(accountNum, bankomat);
            if (account == null) {
                return;
            }
            bankomat.ShowInfo(account.ToString());
            if (IsValidWithdrawal(account, amount, bankomat))
            {
                account.WithdrawFunds(amount);
                bankomat.ShowSuccess(String.Format(
                    WithdrawalSuccessful,
                    amount.ToString(account.CurrencyFormat),
                    account.FormattedAccountNumber));
                bankomat.ShowInfo(account.ToString());
            }
        }

        // ============================== METHOD ==============================
        // DisplayAccount. Prints one account's info.
        // ====================================================================
        public void DisplayAccount(int accountNumber, Bankomat bankomat)
        {
            Account? account = GetAccountByAccountNumber(accountNumber, bankomat);
            if (account != null)
            {
                bankomat.ShowInfo(account.ToString());
            }
        }

        // ============================== METHOD ==============================
        // DisplayAllAccounts. Prints info for all accounts in this bank.
        // ====================================================================
        public void DisplayAllAccounts(Bankomat bankomat)
        {
            if (Accounts == null || Accounts.Length == 0)
            {
                bankomat.ShowError(WarningNoAccountsToPrint);
                return;
            }
            foreach (Account account in Accounts)
            {
                bankomat.ShowInfo(account.ToString());
            }
        }
    }
}
