namespace UppgiftBankomat
{
    internal class Account
    {
        private const string accountNumberFormat = "D6"; // 6 digits e.g. 000001
        private const string currencyFormat = "C"; // currency format e.g. 0,00 kr
        private static int highestAccountNumber = 0;
        
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string CurrencyFormat { get { return currencyFormat; } }
        public string FormattedAccountNumber { get { return AccountNumber.ToString(accountNumberFormat); } }           
        public string FormattedBalance { get {  return Balance.ToString(currencyFormat); } }

        public Account()
        {
            AccountNumber = ++highestAccountNumber;
            Balance = 0.00M;
        }

        public void AddFunds(decimal amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        public void WithdrawFunds(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
                Balance -= amount;
        }

        public override string ToString()
        {
            return $"Konto: {FormattedAccountNumber} Saldo: {FormattedBalance}";
        }
    }
}