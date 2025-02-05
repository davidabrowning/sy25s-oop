using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    internal class Result
    {
        public bool IsSuccessful { get; private set; }
        public string Message { get; private set; }
        internal Result(bool success, string message)
        {
            IsSuccessful = success;
            Message = message;
        }
    }
}
