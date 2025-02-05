using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class Account
    {
        // Success and error messages
        private const string DepositSuccessful = "Du har satt in {0} på konto #{1}. Nuvarande saldo är {2}.";
        private const string DepositMustBeGreaterThanZero = "Insättning måste vara större än {0}.";
        private const string WithdrawalSuccessful = "Du har tagit ut {0} från konto #{1}. Nuvarande saldo är {2}.";
        private const string WithdrawalMustBeGreaterThanZero = "Summa måsta vara större än {0}.";
        private const string BalanceCannotBeLowerThanMinimum = "Saldo får inte bli mindre än {0}."; 

        // Constants
        private const Decimal MinBalance = 0;
        private const Decimal MinDeposit = 0;
        private const Decimal MinWithdrawal = 0;

        // Private variables
        private static int highestAccountNumber = 0;

        // Public properties
        internal int AccountNumber { get; private set; }
        internal Decimal Balance { get; private set; }

        // Constructors
        internal Account()
        {
            AccountNumber = ++highestAccountNumber;
            Balance = 0;
        }
        
        // Methods
        internal Result Deposit(Decimal amount)
        {
            string resultMessage;
            if (amount <= MinDeposit)
            {
                resultMessage = String.Format(DepositMustBeGreaterThanZero, MinDeposit);
                return new Result(false, resultMessage);
            }
            Balance += amount;
            resultMessage = String.Format(DepositSuccessful, amount, AccountNumber, Balance);
            return new Result(true, resultMessage);
        }
        internal Result Withdraw(Decimal amount)
        {
            string resultMessage ;
            if (amount <= MinWithdrawal)
            {
                resultMessage = String.Format(WithdrawalMustBeGreaterThanZero, MinWithdrawal);
                return new Result(false, resultMessage);
            }
            if (Balance - amount < MinBalance)
            {
                resultMessage = String.Format(BalanceCannotBeLowerThanMinimum, MinBalance);
                return new Result(false, resultMessage);
            }
            Balance -= amount;
            resultMessage = String.Format(WithdrawalSuccessful, amount, AccountNumber, Balance);
            return new Result(true, resultMessage);
        }
        public override string ToString()
        {
            string accountNumberString = String.Format("{0:D6}", AccountNumber);
            return $"Konto: #{accountNumberString}, saldo: {Balance}";
        }
        internal static void RunTests()
        {
            // Variables to reuse during testing
            Account account;
            string title;

            Console.WriteLine("Kör tester på Konto-klassen.");

            title = "Saldo är 0 i början";
            account = new Account();
            TestHelper.AssertEquals(title, (Decimal)0, account.Balance);

            title = "Saldo är 5000 efter insättning på 5000";
            account = new Account();
            account.Deposit(5000);
            TestHelper.AssertEquals(title, (Decimal)5000, account.Balance);

            title = "Saldo 25 är 25 efter insättning på -5000";
            account = new Account();
            account.Deposit(25);
            account.Deposit(-5000);
            TestHelper.AssertEquals(title, (Decimal)25, account.Balance);

            title = "Saldo 200 blir 175 efter uttag på 25";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(25);
            TestHelper.AssertEquals(title, (Decimal)175, account.Balance);

            title = "Saldo 200 är 200 efter uttag på 201";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(201);
            TestHelper.AssertEquals(title, (Decimal)200, account.Balance);

            title = "Saldo 200 är 200 efter uttag på -3";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(-3);
            TestHelper.AssertEquals(title, (Decimal)200, account.Balance);

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
