using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningarLinq
{
    internal static class PersonHelper
    {
        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 15; i++)
            {
                people.Add(new Person(GetFirstName(), GetLastName(), GetAge()));
            }
            return people;
        }

        public static string GetFirstName()
        {
            List<string> firstNames = new List<string>();
            firstNames.Add("Johan");
            firstNames.Add("Sven");
            firstNames.Add("Amy");
            firstNames.Add("Anna");
            firstNames.Add("Mary");
            firstNames.Add("Lisa");
            firstNames.Add("Sten");
            firstNames.Add("Magnus");
            return StringHelper.ChooseOne(firstNames);
        }

        public static string GetLastName()
        {
            List<string> lastNames = new List<string>();
            lastNames.Add("Johansson");
            lastNames.Add("Svensson");
            lastNames.Add("Smith");
            lastNames.Add("Jones");
            lastNames.Add("Adams");
            lastNames.Add("Johnson");
            lastNames.Add("Petersson");
            lastNames.Add("Pedersen");
            return StringHelper.ChooseOne(lastNames);
        }

        public static int GetAge()
        {
            Random random = new Random();
            return random.Next(20, 60);
        }
    }
}
