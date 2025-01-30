namespace ClearTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
