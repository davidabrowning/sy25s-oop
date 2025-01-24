namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if ("Monday".CompareTo("Friday") < 0)
            {
                Console.WriteLine("String: Monday comes before Friday");
            }
            else
            {
                Console.WriteLine("String: Monday comes after Friday");
            }

            if (Weekday.Monday < Weekday.Friday)
            {
                Console.WriteLine("Enum: Monday comes before Friday");
            }
            else
            {
                Console.WriteLine("Enum: Monday comes after Friday");
            }

        }
    }
    internal enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }
}