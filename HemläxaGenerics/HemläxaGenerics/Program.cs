namespace HemläxaGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Student student1 = new Student("John");
            Student student2 = new Student("Jane");

            FredriksHelper.PrintParameters(32, 34);
            FredriksHelper.PrintParameters("Hello", "Hej");
            FredriksHelper.PrintParameters(student1, student2);
        }
    }
}
