namespace UtforskningKlasser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(model: "Cherokee", make: "Jeep", year: 1995, color: "Blue");
            myCar.ShowInfo();
        }
    }
}
