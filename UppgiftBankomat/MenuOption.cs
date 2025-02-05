using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftBankomat
{
    // ================================= ENUM =================================
    // MenuOption. Contains integer conversions for each menu option in the 
    // Bankomat's main menu.
    // ========================================================================
    internal enum MenuOption
    {
        Deposit = 1,
        Withdraw = 2,
        DisplayAccount = 3,
        DisplayAllAcounts = 4,
        Quit = 5,
    }
}
