namespace BackingVariablesForProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account(10);
            Console.WriteLine(myAccount.AccountNumber);

            myAccount.updateAccountNumber(1);
            Console.WriteLine(myAccount.AccountNumber);

            myAccount.updateAccountNumber(-1);
            Console.WriteLine(myAccount.AccountNumber);
        }
    }
}
