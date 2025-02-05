using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class Account
    {
        // Constants
        private const int MinBalance = 0;

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
        internal bool Deposit(Decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            Balance += amount;
            return true;
        }
        internal bool Withdraw(Decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            if (Balance - amount < MinBalance)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }
        public override string ToString()
        {
            return $"Konto #{AccountNumber}\t Saldo {Balance}";
        }
        internal static void RunTests()
        {
            // Variables to reuse during testing
            Account account;
            string title;

            Console.WriteLine("Kör tester på Konto-klassen.");

            title = "Saldo är 0.00 i början";
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
