using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParProgrammeringStrumpor
{
    internal class Sock
    {
        // Properties
        public int Size { get; set; }
        public string Color { get; set; }
        public GradeEnum Grade { get; }

        // Constructor
        public Sock(int size, string color, GradeEnum grade)
        {
            Size = size;
            Color = color;
            Grade = grade;
        }

        public override string? ToString()
        {
            return $"Storlek: {Size}, färg: {Color}, betyg: {(int)Grade}";
        }

        // Methods

    }
}
