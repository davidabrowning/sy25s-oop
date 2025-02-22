using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    public class Car : IDriveable
    {
        public int TankCapacity { get; private set; }
        public int GallonsInTank { get; private set; }
        public Car()
        {
            TankCapacity = 20;
            GallonsInTank = 0;
        }
        public void Drive()
        {
            Random rand = new Random();
            GallonsInTank -= rand.Next(0, GallonsInTank + 1);
        }
        public void FillTank()
        {
            Console.WriteLine("Filling up the car!");
            GallonsInTank = TankCapacity;
        }

        public override string ToString()
        {
            return $"This is a car! Tank status is {GallonsInTank} of {TankCapacity}.";
        }
    }
}
