using System.Text.Json;

namespace Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Id = 1, Name = "Fredrik" });
            persons.Add(new Person() { Id = 2, Name = "Lisa" });

            Console.WriteLine("Count: " + persons.Count);

            Console.WriteLine("Unserialized: " + persons);

            string text = JsonSerializer.Serialize(persons);
            Console.WriteLine("Serialized: " + text);

            List<Person> personsList2 = JsonSerializer.Deserialize<List<Person>>(text) ?? new List<Person>();

            Console.WriteLine("Count: " + personsList2.Count);

            Console.WriteLine("Unserialized: " + personsList2);

            string text2 = JsonSerializer.Serialize(personsList2);
            Console.WriteLine("Serialized: " + text2);
        }
    }
}
