using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtforskningPolymorfism
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract override string ToString();
    }
}
