namespace IntParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ange ett heltal:");
            try
            {
                string indata = Console.ReadLine();
                int i = int.Parse(indata);
                Console.WriteLine($"You entered {i} (Parse)");
                int j = Convert.ToInt32(indata);
                Console.WriteLine($"You entered {j} (Convert)");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ogiltig format.");
            }
        }
    }
}
