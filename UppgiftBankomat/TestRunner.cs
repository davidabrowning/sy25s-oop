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
            RunBankTests();
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
            account.AddFunds(5000);
            testHelper.AssertEquals(title, 5000.00M, account.Balance);

            title = "Saldo 25 är 25 efter insättning på -5000";
            account = new Account();
            account.AddFunds(25);
            account.AddFunds(-5000);
            testHelper.AssertEquals(title, 25.00M, account.Balance);

            title = "Saldo 200 blir 175 efter uttag på 25";
            account = new Account();
            account.AddFunds(200);
            account.WithdrawFunds(25);
            testHelper.AssertEquals(title, 175.00M, account.Balance);

            title = "Saldo 200 är 200 efter uttag på 201";
            account = new Account();
            account.AddFunds(200);
            account.WithdrawFunds(201);
            testHelper.AssertEquals(title, 200.00M, account.Balance);

            title = "Saldo 200 är 200 efter uttag på -3";
            account = new Account();
            account.AddFunds(200);
            account.WithdrawFunds(-3);
            testHelper.AssertEquals(title, 200.00M, account.Balance);

            title = "Två konton har olika kontonummer";
            Account a1 = new Account();
            Account a2 = new Account();
            testHelper.AssertNotEquals(title, a1.AccountNumber, a2.AccountNumber);

            title = "ToString() innehåller kontonummer och saldo";
            account = new Account();
            account.AddFunds(1234);
            string accString = account.ToString();
            string accNo = account.AccountNumber.ToString();
            string accBal = account.Balance.ToString(account.CurrencyFormat);
            testHelper.AssertTrue(title, accString.Contains(accNo) && accString.Contains(accBal));
        }

        // ============================== METHOD ==============================
        // RunBankTests. Runs unit tests for the Bank class.
        // ====================================================================
        private void RunBankTests()
        {
            Console.WriteLine("Kör tester på Bank-klassen");

            // Variables to reuse during testing
            Bank bank;
            string title;
            Bankomat bankomat;

            title = "Bank skapad med 10 konton innehåller 10 konton";
            bank = new Bank();
            bank.CreateAccounts(10);
            testHelper.AssertEquals(title, 10, bank.Accounts.Length);

            title = "Bank börjar som null";
            bank = new Bank();
            bankomat = new Bankomat(bank);
            testHelper.AssertTrue(title, bank.Accounts == null);

            title = "Bank har 10 konton efter 5 kontons skapats två gånger";
            bank = new Bank();
            bankomat = new Bankomat(bank);
            bank.CreateAccounts(5);
            bank.CreateAccounts(5);
            testHelper.AssertEquals(title, 10, bank.Accounts.Length);
        }
    }
}
