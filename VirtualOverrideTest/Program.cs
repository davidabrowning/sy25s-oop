namespace VirtualOverrideTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tiger t1 = new Tiger();
            t1.Meow(); // Skriver ut "Tiger meow"
            t1.Purr(); // Skriver ut "Tiger purr"

            Cat t2 = new Tiger();
            t2.Meow(); // Skriver ut "Cat meow" - detta var oväntat
            t2.Purr(); // Skriver ut "Tiger purr"
        }
    }
}