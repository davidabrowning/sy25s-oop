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
        private const string accountNumberFormat = "D6";
        private const string currencyFormat = "C";

        // Fields
        private static int highestAccountNumber = 0;
        
        // Properties
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string CurrencyFormat { get { return currencyFormat; } }
        public string FormattedAccountNumber { get { return AccountNumber.ToString(accountNumberFormat); } }
        public string FormattedBalance { get {  return Balance.ToString(currencyFormat); } }


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
            return $"Konto: {FormattedAccountNumber} Saldo: {FormattedBalance}";
        }
    }
}
