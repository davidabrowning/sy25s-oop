using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // TestRunner. Entry point for unit testing. 
    // ========================================================================
    internal class TestRunner
    {
        // Fields
        TestHelper testHelper = new TestHelper();

        // ============================== METHOD ==============================
        // Go. Runs unit tests for this project.
        // ====================================================================
        public void Go()
        {
            RunAccountTests();
            RunBankomatTests();
        }

        // ============================== METHOD ==============================
        // RunAccountTests. Runs unit tests for the Account class.
        // ====================================================================
        private void RunAccountTests()
        {
            Console.WriteLine("Kör tester på Account-klassen");

            // Variables to reuse during testing
            Account account;
            string title;

            Console.WriteLine("Kör tester på Konto-klassen.");

            title = "Saldo är 0 i början";
            account = new Account();
            testHelper.AssertEquals(title, 0.00M, account.Balance);

            title = "Saldo är 5000 efter insättning på 5000";
            account = new Account();
            account.Deposit(5000);
            testHelper.AssertEquals(title, 5000.00M, account.Balance);

            title = "Saldo 25 är 25 efter insättning på -5000";
            account = new Account();
            account.Deposit(25);
            account.Deposit(-5000);
            testHelper.AssertEquals(title, 25.00M, account.Balance);

            title = "Saldo 200 blir 175 efter uttag på 25";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(25);
            testHelper.AssertEquals(title, 175.00M, account.Balance);

            title = "Saldo 200 är 200 efter uttag på 201";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(201);
            testHelper.AssertEquals(title, 200.00M, account.Balance);

            title = "Saldo 200 är 200 efter uttag på -3";
            account = new Account();
            account.Deposit(200);
            account.Withdraw(-3);
            testHelper.AssertEquals(title, 200.00M, account.Balance);

            title = "Två konton har olika kontonummer";
            Account a1 = new Account();
            Account a2 = new Account();
            testHelper.AssertNotEquals(title, a1.AccountNumber, a2.AccountNumber);

            title = "ToString() innehåller kontonummer och saldo";
            account = new Account();
            account.Deposit(1234);
            string accString = account.ToString();
            string accNo = account.AccountNumber.ToString();
            string accBal = account.Balance.ToString(account.CurrencyFormat);
            testHelper.AssertTrue(title, accString.Contains(accNo) && accString.Contains(accBal));
        }

        // ============================== METHOD ==============================
        // RunBankomatTests. Runs unit tests for the Bankomat class.
        // ====================================================================
        private void RunBankomatTests()
        {
            Console.WriteLine("Kör tester på Bankomat-klassen");

            // Variables to reuse during testing
            Bankomat bankomat;
            string title;

            title = "Bankomat skapad med 10 konton innehåller 10 konton";
            bankomat = new Bankomat(10);
            testHelper.AssertEquals(title, 10, bankomat.Accounts.Length);

            title = "GetAccount(11) initially returns null";
            bankomat = new Bankomat();
            testHelper.AssertTrue(title, bankomat.GetAccountByAccountNumber(5) == null);

            title = "GetAccount(11) returns account #5 after 5 accounts have been created";
            bankomat = new Bankomat(5);
            testHelper.AssertFalse(title, bankomat.GetAccountByAccountNumber(11) == null);
        }
    }
}
