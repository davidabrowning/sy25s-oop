using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningPolymorfism
{
    public class Circle : Shape
    {
        public double Radius { get; }
        public string Type { get; }
        public Circle(double radius)
        {
            Radius = radius;
            Type = "circle";
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return $"{Type} with radius {Radius}, area {CalculateArea()}";
        }
    }
}
