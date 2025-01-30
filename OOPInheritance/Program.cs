namespace OOPInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Fredrik", "Terent");
            Console.WriteLine(p1.Salute());
            Console.WriteLine(p1);

            Student s1 = new Student("John", "Doe");
            s1.Course = "Math";
            Console.WriteLine(s1.Salute());
            Console.WriteLine(s1);

            Teacher t1 = new Teacher();
            t1.FirstName = "Jane";
            t1.LastName = "Roe";
            Console.WriteLine(t1.Salute());
            Console.WriteLine(t1);

        }
    }
}
