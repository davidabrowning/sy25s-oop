using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParProgrammeringStrumpor
{
    internal class Sock
    {
        // Constants
        public const int MinSize = 2;
        public const int MaxSize = 99;

        // Properties
        public int Size { get; }
        public string Color { get; }
        public GradeEnum Grade { get; }

        // Constructor
        public Sock(int size, string color, GradeEnum grade)
        {
            Size = size;
            Color = color;
            Grade = grade;
        }

        // Methods
        public override string ToString()
        {
            return $"Storlek: {Size}, färg: {Color}, betyg: {(int)Grade}";
        }
    }
}
