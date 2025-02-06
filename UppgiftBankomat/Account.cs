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
        private const string DepositSuccessful = "Du har satt in {0} på konto #{1}. Nuvarande saldo är {2}.";
        private const string DepositMustBeGreaterThanZero = "Insättning måste vara minst {0}.";
        private const string WithdrawalSuccessful = "Du har tagit ut {0} från konto #{1}. Nuvarande saldo är {2}.";
        private const string WithdrawalMustBeGreaterThanZero = "Summa måsta vara minst {0}.";
        private const string BalanceCannotBeLowerThanMinimum = "Saldo får inte bli mindre än {0}.";
        private const string AccountSummaryString = "Konto: #{0} Saldo: {1}";

        // Fields
        private static int highestAccountNumber = 0;

        // Properties
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public decimal MinBalance { get; } = 0.00M;
        public decimal MinDeposit { get; } = 0.01M;
        public decimal MinWithdrawal { get; } = 0.01M;
        public string AccountNumberFormat { get; } = "D6";
        public string CurrencyFormat { get; } = "C";

        // Constructors
        public Account()
        {
            AccountNumber = ++highestAccountNumber;
            Balance = 0;
        }

        // ============================== METHOD ==============================
        // Deposit. Accepts a decimal amount and attempts to deposit that
        // amount into this account. Returns a Result object indicating whether
        // the deposit was successful and a relevant message.
        // ====================================================================
        public Result Deposit(decimal amount)
        {
            string resultMessage;
            if (amount < MinDeposit)
            {
                resultMessage = String.Format(DepositMustBeGreaterThanZero,
                    MinDeposit.ToString(CurrencyFormat));
                return new Result(false, resultMessage);
            }
            Balance += amount;
            resultMessage = String.Format(DepositSuccessful, 
                amount.ToString(CurrencyFormat), 
                AccountNumber.ToString(AccountNumberFormat), 
                Balance.ToString(CurrencyFormat));
            return new Result(true, resultMessage);
        }

        // ============================== METHOD ==============================
        // Withdraw. Accepts a decimal amount and attempts to withdraw that
        // amount from this account. Returns a Result object indicating whether
        // the withdrawal was successful and a relevant message.
        // ====================================================================
        public Result Withdraw(decimal amount)
        {
            string resultMessage ;
            if (amount < MinWithdrawal)
            {
                resultMessage = String.Format(WithdrawalMustBeGreaterThanZero, 
                    MinWithdrawal.ToString(CurrencyFormat));
                return new Result(false, resultMessage);
            }
            if (Balance - amount < MinBalance)
            {
                resultMessage = String.Format(BalanceCannotBeLowerThanMinimum, 
                    MinBalance.ToString(CurrencyFormat));
                return new Result(false, resultMessage);
            }
            Balance -= amount;
            resultMessage = String.Format(WithdrawalSuccessful, 
                amount.ToString("C"), 
                AccountNumber.ToString(AccountNumberFormat), 
                Balance.ToString(CurrencyFormat));
            return new Result(true, resultMessage);
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
