using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Tractor : Vehicle
    {
        private int maxSpeed = 30;
        public override int Speed
        {
            get { return speed; }
            set { speed = Math.Min(value, maxSpeed); }
        }
        public Tractor() : base()
        {
            WheelCount = 4;
        }
        public override void Run(int speed)
        {
            this.Speed = Math.Min(speed, this.maxSpeed);
        }
    }
}
