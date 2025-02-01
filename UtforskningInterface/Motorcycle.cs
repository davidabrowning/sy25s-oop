using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    public class Motorcycle : IDriveable
    {
        public int GallonsInTank { get; private set; }
        public int TankCapacity { get; private set; }
        public Motorcycle()
        {
            GallonsInTank = 0;
            TankCapacity = 5;
        }
        public void Drive()
        {
            if (GallonsInTank > 0)
            {
                GallonsInTank--;
            }
        }
        public void FillTank()
        {
            Console.WriteLine("Putting some gas in the motorcycle...");
            GallonsInTank = TankCapacity;
        }
        public override string ToString()
        {
            return $"Motorcycle: {GallonsInTank} of {TankCapacity} gallons in the tank.";
        }
    }
}
