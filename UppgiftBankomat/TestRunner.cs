namespace UppgiftBankomat
{
    internal class TestRunner
    {
        private TestHelper testHelper = new TestHelper();

        public void Go()
        {
            RunAccountTests();
            RunBankTests();
        }

        private void RunAccountTests()
        {
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

        private void RunBankTests()
        {
            // Variables to reuse during testing
            Bank bank;
            string title;
            Bankomat bankomat;

            Console.WriteLine("Kör tester på Bank-klassen");

            title = "Bank skapad med 10 konton innehåller 10 konton";
            bank = new Bank();
            bank.AddAccounts(10);
            testHelper.AssertEquals(title, 10, bank.Accounts.Length);

            title = "Bank har 0 konton i början";
            bank = new Bank();
            bankomat = new Bankomat(bank);
            testHelper.AssertEquals(title, 0, bank.Accounts.Length);

            title = "Bank har 10 konton efter 5 kontons skapats två gånger";
            bank = new Bank();
            bankomat = new Bankomat(bank);
            bank.AddAccounts(5);
            bank.AddAccounts(5);
            testHelper.AssertEquals(title, 10, bank.Accounts.Length);
        }
    }
}
