using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningPolymorfism
{
    public class Rectangle : Shape
    {
        // Public properties
        public double Height { get; }
        public double Width { get; }
        public string Type { get; }

        // Constructor
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
            Type = "rectangle";
        }

        // Methods
        public override double CalculateArea()
        {
            return Height * Width;
        }
        public override string ToString()
        {
            return $"{Type} {Height}x{Width}, area {CalculateArea()}";
        }

    }
}
