using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackingVariablesForProperties
{
    public class Account
    {
        // public int AccountNumber { get; }
        private int accountNumber; // Backing variable
        public int AccountNumber // Property
        {
            get { return accountNumber; }
        }
        public Account(int accountNumber) // Constructor
        {
            this.accountNumber = accountNumber;
        }
        public void updateAccountNumber(int newAccountNumber)
        {
            if (newAccountNumber > 0)
            {
                this.accountNumber = newAccountNumber;
            }
        }
    }
}