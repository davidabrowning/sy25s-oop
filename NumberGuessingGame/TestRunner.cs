using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class TestRunner
    {
        public void RunTests()
        {
            Game.RunTests();
            SaveManager.RunTests();
        }
    }
}
