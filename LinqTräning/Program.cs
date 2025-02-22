namespace LinqTräning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students = StudentHelper.GetStudents();
            Console.WriteLine(students.Count);

            Console.WriteLine("\nUnsorted");
            foreach(Student student in students)
            {
                Console.WriteLine(student.FirstName);
            }

            // LINQ query syntax
            var students2 = from student in students
                            orderby student.FirstName
                            select student;

            Console.WriteLine("\nSorted");
            foreach (Student student in students2)
            {
                Console.WriteLine(student.FirstName);
            }

            // LINQ method syntax
            var students3 = students.OrderBy(x => x.StudyGroup);
            var students4 = students.OrderBy(x => x.StudyGroup)
                .ThenBy(x => x.FirstName);
            Console.WriteLine("\nGrouped");
            foreach (Student student in students4)
            {
                Console.WriteLine(student.FirstName + " " + student.StudyGroup);
            }

            // LINQ method syntax WHERE
            var students5 = students
                .Where(x => x.StudyGroup == 1 && x.City == "Stockholm")
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
            Console.WriteLine("\nGrouped and selected for group 1 and Stockholm");
            foreach (Student student in students5)
            {
                Console.WriteLine(student.FirstName + " " + student.StudyGroup + " " + student.City);
            }

            // LINQ grouping
            var students6 = students.GroupBy(x => x.City);
            Console.WriteLine("\nGroupBy City");
            foreach (var city in students6)
            {
                Console.WriteLine(city.Key + " : " + city.Count());
                foreach (var student in city)
                {
                    Console.WriteLine(" - " + student.FirstName);
                }
            }

            // LINQ grouping by group count
            var students7 = students.GroupBy(x => x.City).OrderByDescending(x => x.Count());
            Console.WriteLine("\nGroupBy City");
            foreach (var city in students7)
            {
                Console.WriteLine(city.Key + " : " + city.Count());
                foreach (var student in city)
                {
                    Console.WriteLine(" - " + student.FirstName);
                }
            }

            // LINQ grouping back to List
            List<Student> students8 = students.OrderBy(x => x.StudyGroup)
                .ThenBy(x => x.FirstName)
                .ToList();
            Console.WriteLine("\nGrouped");
            foreach (Student student in students8)
            {
                Console.WriteLine(student.FirstName + " " + student.StudyGroup);
            }
        }
    }
}
