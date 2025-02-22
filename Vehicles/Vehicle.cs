using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Vehicle
    {
		protected int speed;
        protected int wheelCount;
        public virtual int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int WheelCount
		{
			get { return wheelCount; }
			set { wheelCount = value; }
		}
        public void Stop()
        {
            Speed = 0;
        }
        public virtual void Run(int speed)
        {
            Speed = speed;
        }
        public override string? ToString()
        {
            return $"{TypeDescriptor.GetClassName(this).Substring(9, 3)}, wheels: {WheelCount}, speed: {Speed}kph";
        }
    }
}
