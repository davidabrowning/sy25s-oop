using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public string Color { get; set; }
        public Car() : base() 
        {
            WheelCount = 4;
            Color = "gray";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, color: {Color}";
        }
    }
}
