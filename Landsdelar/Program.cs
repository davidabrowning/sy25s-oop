namespace Landsdelar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Landsdel kalleLandsdel = Landsdel.Norrland;
            Landsdel lisaLandsdel = Landsdel.Svealand;
            Landsdel algotLandsdel = Landsdel.Götaland;

            Console.WriteLine("Skriver ut elevernas landsdelar:");
            Console.WriteLine("Kalle: " + kalleLandsdel);
            Console.WriteLine("Lisa: " + lisaLandsdel);
            Console.WriteLine("Algot: " + algotLandsdel);
        }
    }

    internal enum Landsdel
    {
        Norrland,
        Svealand,
        Götaland
    }
}
