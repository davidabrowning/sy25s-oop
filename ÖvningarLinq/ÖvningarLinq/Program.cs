using System.Text.Json;

namespace ÖvningarLinq
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // Övning 1: OrderBy och ThenBy
            Console.WriteLine("1. OrderBy och ThenBy");
            List<Person> people = PersonHelper.GetPeople();
            people = people
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList();
            foreach(Person person in people)
            {
                Console.WriteLine(person);
            }

            // Mellan övningar
            Console.WriteLine("=====================================");

            // Övning 2: GroupBy
            Console.WriteLine("2. GroupBy");
            List<Product> products = ProductHelper.GetProducts();
            var categories = products
                .GroupBy(p => p.Category)           // Group by cat
                .OrderByDescending(c => c.Count())  // Order by cat count
                .ThenBy(c => c.Key)                 // Order by cat name
                .ToList();                          // Put into a list       
            foreach(var category in categories)
            {
                Console.WriteLine($"{category.Key} ({category.Count()})");  // Print cat
                foreach(var product in category)
                {
                    Console.WriteLine($" - {product.ToString()}");          // Print product
                }
            }

            // Mellan övningar
            Console.WriteLine("=====================================");

            // Övning 3: Kombinera OrderBy, GroupBy och ThenBy
            Console.WriteLine("3. Kombinera OrderBy, GroupBy och ThenBy");
            List<Student> students = StudentHelper.GetStudents();
            var courses = students
                .OrderBy(s => s.Course)
                .ThenBy(s => s.Age)
                .ThenBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .GroupBy(s => s.Course);
            foreach (var course in courses)
            {
                Console.WriteLine(course.Key);
                foreach(Student student in course)
                {
                    Console.WriteLine(" - " + student);
                }
            }

            // Mellan övningar
            Console.WriteLine("=====================================");

            // Övning 4: Läs från JSON och sortera med OrderBy och ThenBy
            Console.WriteLine("4. OrderBy och ThenBy från fil");
            string fileText4 = File.ReadAllText("ovning4.json");
            List<Person> peopleFromFile = JsonSerializer.Deserialize<List<Person>>(fileText4) ?? new List<Person>();
            peopleFromFile = peopleFromFile
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList();
            foreach (Person person in peopleFromFile)
            {
                Console.WriteLine(person);
            }

            // Mellan övningar
            Console.WriteLine("=====================================");

            // Övning 5: GroupBy från file
            Console.WriteLine("5. GroupBy från fil");
            string fileText5 = File.ReadAllText("ovning5.json");
            List<Product> productsFromFile = JsonSerializer.Deserialize<List<Product>>(fileText5) ?? new List<Product>();
            var categoriesFromFile = productsFromFile
                .OrderBy(p => p.Name)               // Order by product name
                .GroupBy(p => p.Category)           // Group by cat
                .OrderByDescending(c => c.Count())  // Order by cat count
                .ThenBy(c => c.Key)                 // Order by cat name
                .ToList();                          // Put into a list       
            foreach (var category in categoriesFromFile)
            {
                Console.WriteLine($"{category.Key} ({category.Count()})");  // Print cat
                foreach (var product in category)
                {
                    Console.WriteLine($" - {product.ToString()}");          // Print product
                }
            }

        }


    }
}
