using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================ CLASS =================================
    // Result. Contains bool and string, to help methods return both a bool
    // result and relevant success/failure message.
    // ========================================================================
    internal class Result
    {
        // Properties
        public bool IsSuccessful { get; private set; }
        public string Message { get; private set; }

        // Constructor
        internal Result(bool success, string message)
        {
            IsSuccessful = success;
            Message = message;
        }
    }
}
