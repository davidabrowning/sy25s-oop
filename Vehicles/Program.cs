using System.ComponentModel.DataAnnotations;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Car c1 = new Car();
            Car c2 = new Car();
            Tractor t1 = new Tractor();
            Tractor t2 = new Tractor();
            Motorcycle m1 = new Motorcycle();
            Motorcycle m2 = new Motorcycle();
            Tricycle y1 = new Tricycle();
            Tricycle y2 = new Tricycle();

            vehicles.Add(c1);
            vehicles.Add(c2);
            vehicles.Add(t1);
            vehicles.Add(t2);
            vehicles.Add(m1);
            vehicles.Add(m2);
            vehicles.Add(y1);
            vehicles.Add(y2);

            c1.Run(10);
            c2.Run(99);
            t1.Run(10);
            t2.Run(99);
            m1.Run(10);
            m2.Run(99);
            y1.Run(10);
            y2.Run(99);

            PrintAllVehicles(vehicles);
        }

        private static void PrintAllVehicles(List<Vehicle> vehicles)
        {
            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v);
            }
        }
    }
}
