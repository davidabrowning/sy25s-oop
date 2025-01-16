namespace VSDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hälsa();
            KollaLängd();
            KollaNorrlänning();
            // KollaJämntTal();
            ÖvningPythagoreanTheorem(32, 20);
            ÖvningOmkretsen(5);
            ÖvningCelsiusTillFahrenheit(-40);
            ÖvningCelsiusTillFahrenheit(0);
            ÖvningCelsiusTillFahrenheit(100);
            ÖvningMedelvärdet(2, 2, 3);
            ÖvningMedelvärdet(2, 2, 4);
            ÖvningJämntEllerUdda(5);
            ÖvningJämntEllerUdda(5000);
        }

        static void ÖvningJämntEllerUdda(int tal)
        {
            SkrivTitel("Metod: JämntEllerUdda");
            bool jämnt = tal % 2 == 0;
            if (jämnt)
                Console.WriteLine(tal + " är jämnt.");
            else
                Console.WriteLine(tal + " är udda");
        }

        static void ÖvningMedelvärdet(int a, int b, int c)
        {
            SkrivTitel("Metod: Medelvärdet");
            double medelvärdet = (double) (a + b + c) / 3;
            Console.WriteLine("Värden: " + a + " " + b + " " + c + ", medelvärdet: " + medelvärdet);
        }

        static void ÖvningCelsiusTillFahrenheit(double celsius)
        {
            SkrivTitel("Metod: CelsiusTillFahrenheit");
            double fahrenheit = celsius * 9 / 5 + 32;
            Console.WriteLine("Celsius: " + celsius + ", Fahrenheit: " + fahrenheit);
        }

       static void ÖvningOmkretsen(int radius)
        {
            SkrivTitel("Metod: ÖvningOmkretsen");
            double omkretsen = 2 * Math.PI * radius;
            Console.WriteLine("Radius: " + radius + ", omkretsen: " + omkretsen);
        }

        static void ÖvningPythagoreanTheorem(int a, int b)
        {
            SkrivTitel("Metod: ÖvningPythagoreanTheorem");
            double c = Math.Sqrt(a * a + b * b);
            Console.WriteLine("Sides: " + a + ", " + b + ", " + c);
            Console.WriteLine("a * a = " + (a * a));
            Console.WriteLine("b * b = " + (b * b));
            Console.WriteLine("c * c = " + Math.Round(c * c));
        }

        static void KollaJämntTal()
        {
            SkrivTitel("Metod: KollaGemtTal");

            int number;
            Console.WriteLine("Ange ett tal:");
            number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Jämnt nummer.");
            }
            else
            {
                Console.WriteLine("Ojämnt nummer.");
            }
            Console.WriteLine(Math.PI);
        }

        static void KollaNorrlänning()
        {
            SkrivTitel("Metod: KollaNorrlänning");
            bool isNorrlänning = false;
            Console.WriteLine("isNorlänning: " + isNorrlänning);
            if (isNorrlänning)
            {
                Console.WriteLine("Du använder nog dubbdäck.");
            }
            else
            {
                Console.WriteLine("Du använder nog dubbfria däck.");
            }
        }

        static void KollaLängd()
        {
            SkrivTitel("Metod: KollaLängd");
            int lengthInCentimeters = 176;
            Console.WriteLine("Längd: " + lengthInCentimeters);

            if (++lengthInCentimeters > 176)
            {
                Console.WriteLine("Du är lång!");
            }

            Console.WriteLine("Längd: " + lengthInCentimeters);
        }

        static void Hälsa()
        {
            SkrivTitel("Metod: Hälsa");
            Console.WriteLine("Hello, World!");
            FredriksKlass.Greet();
        }

        static void SkrivTitel(string titel)
        {
            Console.WriteLine("\n============= " + titel + " =============");
        }
    }
}
