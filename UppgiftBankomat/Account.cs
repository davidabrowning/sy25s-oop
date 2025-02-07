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

        // ============================== METHOD ==============================
        // AddFunds. Accepts a decimal amount, checks if the amount is greater
        // than 0, and adds the amount to this account's balance.
        // ====================================================================
        public void AddFunds(decimal amount)
        {
            if (amount > 0) { Balance += amount; }
        }

        // ============================== METHOD ==============================
        // WithdrawFunds. Accepts a decimal amount, checks if the amount is
        // greater than 0 and less than or equal to Balance, and removes the
        // amount from this account's balance.
        // ====================================================================
        public void WithdrawFunds(decimal amount)
        {
            if (amount > 0 && amount <= Balance) { Balance -= amount; }
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
