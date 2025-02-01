namespace UtforskningArv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Cat("The Mayor", 15));
            animals.Add(new Dog("Bill", 8));
            foreach (Animal animal in animals)
            {
                animal.MakeNoise();
            }
        }
    }
}
