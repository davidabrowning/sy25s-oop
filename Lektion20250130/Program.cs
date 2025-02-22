using System.Text.Json;

namespace Lektion20250130
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create
            //Student s1 = new Student("John", "Doe");
            //Student s2 = new Student("Jane", "Roe");
            //List<Student> students = new List<Student>();
            //students.Add(s1);
            //students.Add(s2);

            // Read from file
            List<Student> students = ReadStudentListFromFile();
            // List<Student> students = new List<Student>();

            // Print all Students
            Console.WriteLine("Initial file read");
            PrintStudentList(students);

            // Add one more Student
            students.Add(new Student("Jim", "Doe"));

            // Serialize and write to file
            string serializedStudentList = JsonSerializer.Serialize(students);
            File.WriteAllText("StudentList.json", serializedStudentList);

            // Read from file
            students = ReadStudentListFromFile();

            // Print all Students
            Console.WriteLine("\nFinal file read");
            PrintStudentList(students);
        }

        private static List<Student> ReadStudentListFromFile()
        {
            string studentsAsReadFromFile = File.ReadAllText("StudentList.json");
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(studentsAsReadFromFile) ?? new List<Student>();
            return students;
        }

        private static void PrintStudentList(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
