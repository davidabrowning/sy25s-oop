namespace UppgiftBankomat
{
    internal class Bank : IAccountRepository
    {
        private const decimal minBalance = 0.00M;
        private const decimal minDeposit = 0.01M;
        private const decimal minWithdrawal = 0.01M;
        private const string WarningAccountNotFound  = "Lyckades inte hitta detta konto.";
        private const string WarningDepositMustBeGreaterThanMinDeposit  = "Insättning måste vara minst {0}.";
        private const string WarningWithdrawalMustBeGreaterThanMinWithdrawal  = "Uttag måsta vara minst {0}.";
        private const string WarningBalanceCannotBeLowerThanMinimum  = "Saldo får inte bli mindre än {0}.";
        private const string WarningNoAccountsToPrint   = "Lyckades inte hitta några konton.";

        public Account[] Accounts { get; private set; }

        public Bank()
        {
            Accounts = new Account[0];
        }

        public void AddAccounts(int accountsToCreate)
        {
            Account[] newAccounts = CreateAccounts(accountsToCreate);
            Accounts = CombineAccountArrays(Accounts, newAccounts);
        }

        private Account[] CreateAccounts(int accountsToCreate) {
            Account[] createdAccounts = new Account[accountsToCreate];
            for (int i = 0; i < createdAccounts.Length; i++)
                createdAccounts[i] = new Account();
            return createdAccounts;
        }

        private Account[] CombineAccountArrays(Account[] firstAccountArray, Account[] secondAccountArray)
        {
            Account[] combinedAccounts = new Account[firstAccountArray.Length + secondAccountArray.Length];
            int combinedAccountIndex = 0;
            foreach (Account account in firstAccountArray)
                combinedAccounts[combinedAccountIndex++] = account;
            foreach (Account account in secondAccountArray)
                combinedAccounts[combinedAccountIndex++] = account;
            return combinedAccounts;
        }

        public void Deposit(int accountNumber, decimal depositAmount)
        {

            if (!AccountExists(accountNumber))
                throw new Exception(WarningAccountNotFound);

            Account account = GetAccount(accountNumber);

            if (depositAmount < minDeposit)
                throw new Exception(String.Format(WarningDepositMustBeGreaterThanMinDeposit, 
                    minDeposit.ToString(account.CurrencyFormat)));

            decimal newBalance = account.Balance + depositAmount;
            if (newBalance < minBalance)
                throw new Exception(String.Format(WarningBalanceCannotBeLowerThanMinimum, minBalance));

            account.AddFunds(depositAmount);
        }

        public void Withdraw(int accountNumber, decimal withdrawalAmount)
        {
            if (!AccountExists(accountNumber))
                throw new Exception(WarningAccountNotFound);

            Account account = GetAccount(accountNumber);

            if (withdrawalAmount < minWithdrawal)
                throw new Exception(String.Format(WarningWithdrawalMustBeGreaterThanMinWithdrawal, 
                    minWithdrawal.ToString(account.CurrencyFormat)));

            decimal newBalance = account.Balance - withdrawalAmount;
            if (newBalance < minBalance)
                throw new Exception(String.Format(WarningBalanceCannotBeLowerThanMinimum, 
                    minBalance.ToString(account.CurrencyFormat)));

            account.WithdrawFunds(withdrawalAmount);
        }

        private bool AccountExists(int accountNumber)
        {
            foreach (Account account in Accounts)
                if (account.AccountNumber == accountNumber)
                    return true;
            return false;
        }

        private Account GetAccount(int accountNumber)
        {
            foreach (Account account in Accounts)
                if (account.AccountNumber == accountNumber)
                    return account;
            throw new Exception(WarningAccountNotFound);
        }

        public string GetAccountSummary(int accountNumber)
        {
            try
                {
                    return GetAccount(accountNumber).ToString();
                }
                catch (Exception e)
                {
                    throw new Exception(WarningAccountNotFound);
            }
        }

        public string[] GetAllAccountSummaries()
        {
            if (Accounts.Length == 0)
                throw new Exception(WarningNoAccountsToPrint);

            string[] accountSummaries = new string[Accounts.Length];
            int accountSummaryIndex = 0;

            foreach (Account account in Accounts.OrderBy(a => a.AccountNumber))
                accountSummaries[accountSummaryIndex++] = account.ToString();

            return accountSummaries;
        }
    }
}
