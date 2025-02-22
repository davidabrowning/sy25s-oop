using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    interface IInputDevice
    {
        string GetStringInput();
        int GetIntInput();
        decimal GetDecimalInput();
    }
}
