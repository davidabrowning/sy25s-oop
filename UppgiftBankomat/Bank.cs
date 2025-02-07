using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class Bank
    {
        // Constants
        private const string WarningIllegalAccountNumber = "Lyckades inte hitta konto med det kontonumret. Försök igen.";
        private const string DepositSuccessful = "Du har satt in {0} på konto #{1}.";
        private const string WarningDepositMustBeGreaterThanMinDeposit = "Insättning måste vara minst {0}.";
        private const string WithdrawalSuccessful = "Du har tagit ut {0} från konto #{1}.";
        private const string WarningWithdrawalMustBeGreaterThanMinWithdrawal = "Summa måsta vara minst {0}.";
        private const string WarningBalanceCannotBeLowerThanMinimum = "Saldo får inte bli mindre än {0}.";
        private const string WarningNoAccountsToPrint = "Det finns inga konton att skriva ut.";
        private const decimal minBalance = 0.00M;
        private const decimal minDeposit = 0.01M;
        private const decimal minWithdrawal = 0.01M;

        // Fields

        // Properties
        public Account[]? Accounts { get; private set; }

        public void CreateAccounts(int accountsToCreate)
        {
            Accounts = new Account[accountsToCreate];
            for (int i = 0; i < Accounts.Length; i++)
            {
                Accounts[i] = new Account();
            }
        }

        // ============================== METHOD ==============================
        // GetAccountByAccountNumber. Accepts an int accountNumber and 
        // returns the account with the matching account number. Returns null
        // if no matches are found.
        // ====================================================================
        public Account? GetAccountByAccountNumber(int accountNumber)
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
        // Deposit. Accepts an account number, deposit amount, and origin bankomat and attempts to deposit the
        // amount into the account. Returns a Result object indicating whether
        // the deposit was successful and a relevant message.
        // ====================================================================
        public void Deposit(int accountNumber, decimal amount, Bankomat bankomat)
        {
            Account? account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                bankomat.ShowError(WarningIllegalAccountNumber);
                return;
            }
            if (amount < minDeposit)
            {
                bankomat.ShowError(String.Format(
                    WarningDepositMustBeGreaterThanMinDeposit,
                    minDeposit.ToString(account.CurrencyFormat)));
                return;
            }
            if (account.Balance + amount < minBalance)
            {
                bankomat.ShowError(String.Format(
                    WarningBalanceCannotBeLowerThanMinimum,
                    minBalance));
                return;
            }
            account.AddFunds(amount);
            bankomat.ShowSuccess(String.Format(
                DepositSuccessful, 
                amount.ToString(account.CurrencyFormat),
                account.FormattedAccountNumber));
            bankomat.ShowInfo(account.ToString());
        }

        // ============================== METHOD ==============================
        // Withdraw. Accepts a decimal amount and attempts to withdraw that
        // amount from this account. Returns a Result object indicating whether
        // the withdrawal was successful and a relevant message.
        // ====================================================================
        public void Withdraw(int accountNumber, decimal amount, Bankomat bankomat)
        {
            Account account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                bankomat.ShowError(WarningIllegalAccountNumber);
                return;
            }
            if (amount < minWithdrawal)
            {
                bankomat.ShowError(String.Format(
                    WarningWithdrawalMustBeGreaterThanMinWithdrawal,
                    minWithdrawal.ToString(account.CurrencyFormat)));
                return;
            }
            if (account.Balance - amount < minBalance)
            {
                bankomat.ShowError(String.Format(
                    WarningBalanceCannotBeLowerThanMinimum,
                    minBalance.ToString(account.CurrencyFormat)));
                return;
            }
            account.WithdrawFunds(amount);
            bankomat.ShowSuccess(String.Format(
                WithdrawalSuccessful,
                amount.ToString(account.CurrencyFormat),
                account.FormattedAccountNumber));
            bankomat.ShowInfo(account.ToString());
        }

        // ============================== METHOD ==============================
        //
        // ====================================================================
        public void DisplayAccount(int accountNumber, Bankomat bankomat)
        {
            Account? account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                bankomat.ShowError(WarningIllegalAccountNumber);
                return;
            }
            bankomat.ShowInfo(account.ToString());
        }

        // ============================== METHOD ==============================
        //
        // ====================================================================
        public void DisplayAllAccounts(Bankomat bankomat)
        {
            if (Accounts.Length == 0)
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
