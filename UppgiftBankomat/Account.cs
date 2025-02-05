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
        private const decimal MinBalance = (decimal)0.00;
        private const decimal MinDeposit = (decimal)0.01;
        private const decimal MinWithdrawal = (decimal)0.01;
        private const string AccountNumberFormat = "D6";
        private const string CurrencyFormat = "C";

        // Fields
        private static int highestAccountNumber = 0;

        // Properties
        internal int AccountNumber { get; private set; }
        internal decimal Balance { get; private set; }

        // Constructors
        internal Account()
        {
            AccountNumber = ++highestAccountNumber;
            Balance = 0;
        }

        // ============================== METHOD ==============================
        // Deposit. Accepts a decimal amount and attempts to deposit that
        // amount into this account. Returns a Result object indicating whether
        // the deposit was successful and a relevant message.
        // ====================================================================
        internal Result Deposit(decimal amount)
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
        internal Result Withdraw(decimal amount)
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

        // ============================== METHOD ==============================
        // RunTests. Static method that runs unit tests for this class.
        // ====================================================================
        internal static void RunTests()
        {
            // Variables to reuse during testing
            Account account;
            string title;

            Console.WriteLine("Kör tester på Konto-klassen.");

            title = "Saldo är 0 i början";
            account = new Account();
            TestHelper.AssertEquals(title, (decimal)0, account.Balance);

            title = "Saldo är 5000 efter insättning på 5000";
            account = new Account();
            account.Deposit(5000);
            TestHelper.AssertEquals(title, (decimal)5000, account.Balance);

            title = "Saldo 25 är 25 efter insättning på -5000";
            account = new Account();
            account.Deposit(25);
            account.Deposit(-5000);
            TestHelper.AssertEquals(title, (decimal)25, account.Balance);

            title = "Saldo 200 blir 175 efter uttag på 25";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(25);
            TestHelper.AssertEquals(title, (decimal)175, account.Balance);

            title = "Saldo 200 är 200 efter uttag på 201";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(201);
            TestHelper.AssertEquals(title, (decimal)200, account.Balance);

            title = "Saldo 200 är 200 efter uttag på -3";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(-3);
            TestHelper.AssertEquals(title, (decimal)200, account.Balance);

            title = "Två konton har olika kontonummer";
            Account a1 = new Account();
            Account a2 = new Account();
            TestHelper.AssertNotEquals(title, a1.AccountNumber, a2.AccountNumber);

            title = "ToString() innehåller kontonummer och saldo";
            account = new Account();
            account.Deposit(1234);
            string accString = account.ToString();
            string accNo = account.AccountNumber.ToString();
            string accBal = account.Balance.ToString();
            TestHelper.AssertTrue(title, accString.Contains(accNo) && accString.Contains(accBal));
        }
    }
}
