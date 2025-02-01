namespace InterfacePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IDriveable> vehicles = new List<IDriveable>();
            vehicles.Add(new Car());
            vehicles.Add(new Motorcycle());
            foreach (IDriveable vehicle in vehicles)
            {
                Console.WriteLine("============");
                Console.WriteLine(vehicle);
                vehicle.FillTank();
                Console.WriteLine(vehicle);
                vehicle.Drive();
                Console.WriteLine(vehicle);
                vehicle.Drive();
                Console.WriteLine(vehicle);
                vehicle.Drive();
                Console.WriteLine(vehicle);
                vehicle.FillTank();
                Console.WriteLine(vehicle);
            }
            Console.WriteLine("============");
        }
    }
}
