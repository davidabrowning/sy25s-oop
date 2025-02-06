using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Account. Models a bank account, including account number and account
    // balance, as well as ways to interact with the account (deposit money,
    // withdraw money).
    // ========================================================================
    internal class Account
    {
        // Constants
        private const string AccountSummaryString = "Konto: #{0} Saldo: {1}";

        // Fields
        private static int highestAccountNumber = 0;

        // Properties
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string AccountNumberFormat { get; } = "D6";
        public string CurrencyFormat { get; } = "C";

        // Constructors
        public Account()
        {
            AccountNumber = ++highestAccountNumber;
            Balance = 0;
        }

        public void AddFunds(decimal amount)
        {
            if (amount > 0) { Balance += amount; }
        }

        public void WithdrawFunds(decimal amount)
        {
            if (Balance >= amount) { Balance -= amount; }
        }

        // ============================== METHOD ==============================
        // ToString. Overrides the Object.ToString() method. Returns a string
        // representation of this Account object.
        // ====================================================================
        public override string ToString()
        {
            return String.Format(AccountSummaryString, 
                AccountNumber.ToString(AccountNumberFormat), 
                Balance.ToString(CurrencyFormat));
        }
    }
}
