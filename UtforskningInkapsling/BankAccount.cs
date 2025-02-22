using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningInkapsling
{
    public class BankAccount
    {
        private static int nextAccountNumber = 1001;
        private int accountNumber;
        private Decimal balance;
        public BankAccount()
        {
            accountNumber = nextAccountNumber++;
            balance = 0M;
            Console.WriteLine($"Account {accountNumber} created. Balance {balance}:-.");
        }
        public bool Deposit(Decimal amount)
        {
            if(amount > 0)
            {
                balance += amount;
                Console.WriteLine($"{amount} deposited.");
                return true;
            }
            else
            {
                Console.WriteLine($"Unable to deposit {amount}:-.");
                return false;
            }
            
        }
        public bool Withdraw(Decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"{amount} withdrawn.");
                return true;
            }
            else
            {
                Console.WriteLine($"Unable to withdraw {amount}:-.");
                return false;
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine("#########################");
            Console.WriteLine($"# Account number: {accountNumber}");
            Console.WriteLine($"# Balance: {balance}:-.");
            Console.WriteLine("#########################");
        }
    }
}
