namespace UppgiftBankomat
{
    internal class Bank
    {
        private const decimal minBalance = 0.00M;
        private const decimal minDeposit = 0.01M;
        private const decimal minWithdrawal = 0.01M;
        private const string WarningAccountNotFound  = "Lyckades inte hitta detta konto.";
        private const string DepositSuccessful  = "Du har satt in {0} på konto #{1}.";
        private const string WarningDepositMustBeGreaterThanMinDeposit  = "Insättning måste vara minst {0}.";
        private const string WithdrawalSuccessful  = "Du har tagit ut {0} från konto #{1}.";
        private const string WarningWithdrawalMustBeGreaterThanMinWithdrawal  = "Summa måsta vara minst {0}.";
        private const string WarningBalanceCannotBeLowerThanMinimum  = "Saldo får inte bli mindre än {0}.";
        private const string WarningNoAccountsToPrint   = "Lyckades inte hitta några konton.";

        public Account[] Accounts { get; private set; }

        public Bank()
        {
            Accounts = new Account[0];
        }

        public void CreateAccounts(int accountsToCreate)
        {
            Account[] existingAccounts = Accounts;
            Account[] newAccounts = new Account[accountsToCreate];
            Accounts = new Account[existingAccounts.Length + newAccounts.Length];

            // Create new accounts
            for (int i = 0; i < newAccounts.Length; i++)
                newAccounts[i] = new Account();
            // Transfer existing accounts
            for (int i = 0; i < existingAccounts.Length; i++)
                Accounts[i] = existingAccounts[i];
            // Transfer new accounts
            for (int i = 0; i < accountsToCreate; i++)
                Accounts[existingAccounts.Length + i] = newAccounts[i];
        }

        public Account GetAccountByAccountNumber(int accountNumber, Bankomat bankomat)
        {
            foreach (Account account in Accounts)
                if (account.AccountNumber == accountNumber)
                    return account;
            throw new Exception(WarningAccountNotFound);
        }

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

        public void Deposit(int accountNum, decimal amount, Bankomat bankomat)
        {
            try
            {
                Account account = GetAccountByAccountNumber(accountNum, bankomat);
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
            catch (Exception e)
            {
                bankomat.ShowError(e.Message);
            }
        }

        public void Withdraw(int accountNum, decimal amount, Bankomat bankomat)
        {
            try {
                Account account = GetAccountByAccountNumber(accountNum, bankomat);
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
            catch (Exception e)
            {
                bankomat.ShowError(e.Message);
            }

        }

        public void DisplayAccount(int accountNumber, Bankomat bankomat)
        {
            try 
            {
                Account account = GetAccountByAccountNumber(accountNumber, bankomat);
                bankomat.ShowInfo(account.ToString());
            }
            catch (Exception e)
            {
                bankomat.ShowError(e.Message);
            }
        }

        public void DisplayAllAccounts(Bankomat bankomat)
        {
            if (Accounts.Length == 0)
                bankomat.ShowError(WarningNoAccountsToPrint);
            foreach (Account account in Accounts.OrderBy(a => a.AccountNumber))
                bankomat.ShowInfo(account.ToString());
        }
    }
}
