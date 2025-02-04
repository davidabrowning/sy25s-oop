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
        private const string SuccessAccountCreated = "Du har skapat konto #{0} med saldo {1}.";
        private const string SuccessDeposit = "Du har satt in {0} på konto #{1}. Nuvarande saldo är {2}.";
        private const string SuccessWithdrawal = "Du har tagit ut {0}. Nuvarande saldo är {1}.";
        private const string WarningDepositMustBeGreaterThanZero = "Insättning måste vara större än 0.00.";
        private const string WarningWithdrawalMustBeGreaterThanZero = "Uttag måste vara större än 0.00.";
        private const string WarningWithdrawalTooLarge = "Detta uttag skulle göra saldo mindre än minimum saldo-värdet.";

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
            Printer.PrintSuccess(String.Format(SuccessAccountCreated, AccountNumber, Balance));
        }
        
        // Methods
        internal void Deposit(Decimal amount)
        {
            if (amount <= 0)
            {
                Printer.PrintWarning(WarningDepositMustBeGreaterThanZero);
                return;
            }
            Balance += amount;
            Printer.PrintSuccess(String.Format(SuccessDeposit, amount, AccountNumber, Balance));
        }
        internal void Withdraw(Decimal amount)
        {
            if (amount <= 0)
            {
                Printer.PrintWarning(WarningWithdrawalMustBeGreaterThanZero);
                return;
            }
            if (Balance - amount < MinBalance)
            {
                Printer.PrintWarning(WarningWithdrawalTooLarge);
                return;
            }
            Balance -= amount;
            Printer.PrintSuccess(String.Format(SuccessWithdrawal, amount, Balance));
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

            Printer.PrintSubtitle("Kör tester på Konto-klassen.");

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
