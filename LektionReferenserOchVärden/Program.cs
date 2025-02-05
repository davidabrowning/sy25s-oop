namespace LektionReferenserOchVärden
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            DavidsNumber d = new DavidsNumber();
            d.Value = 0;

            Console.WriteLine("int i, DavidsNumber d");

            Console.WriteLine("\nMain()");
            Console.WriteLine($"i = {i}, d = {d}");
            Console.WriteLine("Leaving Main()");

            Increment(i, d);

            Console.WriteLine("\nMain()");
            Console.WriteLine($"i = {i}, d = {d}");
            Console.WriteLine("Leaving Main()");

            Console.WriteLine("\nENTER to quit");
            Console.ReadLine();
        }
        private static void Increment(int i, DavidsNumber d)
        {
            Console.WriteLine("\nIncrement()");
            Console.WriteLine($"i = {i}, d = {d}");
            i++;
            d.Value++;
            Console.WriteLine($"i = {i}, d = {d}");
            Console.WriteLine("Leaving Increment()");
        }
    }
    
    internal class DavidsNumber
    {
        public int Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
