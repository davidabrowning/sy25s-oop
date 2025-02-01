using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    public interface IDriveable
    {
        int TankCapacity { get; }
        int GallonsInTank { get; }
        void Drive();
        void FillTank();
    }
}
