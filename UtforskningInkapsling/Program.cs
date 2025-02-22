namespace UtforskningInkapsling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount();
            myAccount.ShowBalance();
            myAccount.Withdraw(100);
            myAccount.ShowBalance();
            myAccount.Deposit(522.75M);
            myAccount.ShowBalance();
            myAccount.Withdraw(100);
            myAccount.ShowBalance();
        }
    }
}
