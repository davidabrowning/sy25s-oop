using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    interface IAccountRepository
    {
        void AddAccounts(int accountsToCreate);
        void Deposit(int accountNumber, decimal amount);
        void Withdraw(int accountNumber, decimal amount);
        string GetAccountSummary(int accountNumber);
        string[] GetAllAccountSummaries();
    }
}
