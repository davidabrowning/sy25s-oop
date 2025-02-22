namespace Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            List<Student> students = new List<Student>();

            // Test data
            Student student1 = new Student("Sven", "Svensson", new DateOnly(1970, 10, 25), "dotNET25");
            students.Add(student1);

            while(run)
            {
                PrintMenu();
                switch(Console.ReadLine().ToUpper())
                {
                    case "1":
                        students.Add(GetNewStudentFromUser());
                        break;
                    case "2":
                        RemoveStudent(students);
                        break;
                    case "3":
                        PrintStudents(students);
                        break;
                    case "4":
                        PrintCourseList();
                        break;
                    case "Q":
                        Console.WriteLine("Quitting program.");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Unexpected input. Try again.");
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Main menu =====");
            Console.WriteLine("[1] Add student");
            Console.WriteLine("[2] Remove student");
            Console.WriteLine("[3] Print students");
            Console.WriteLine("[4] Print course list");
            Console.WriteLine("[Q] Quit");
            Console.Write("Your selection: ");
        }

        static void PrintCourseList()
        {
            Console.Clear();
            Console.WriteLine("===== Course list =====");
            foreach(int i in Enum.GetValues(typeof(Course)))
            {
                Console.WriteLine((Course) i);
            }
            Console.WriteLine("\nENTER to return to main menu.");
            Console.ReadLine();
        }

        static void RemoveStudent(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("===== Remove student =====");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.Write("Id of student to remove (Q to cancel): ");
            string userInput = Console.ReadLine().ToUpper();
            switch (userInput){
                case "Q":
                    break;
                default:
                    Int32.TryParse(userInput, out int studentIdToRemove);
                    if (studentIdToRemove > 0)
                    {
                        Student studentToRemove = null;
                        foreach(Student student in students)
                        {
                            if (student.StudentId == studentIdToRemove)
                            {
                                studentToRemove = student;
                            }
                        }
                        if (studentToRemove != null)
                        {
                            students.Remove(studentToRemove);
                            Console.WriteLine("Student removed.");
                        }
                        else
                        {
                            Console.WriteLine("Unable to find student.");
                        }

                    }
                    break;
            }

            Console.WriteLine("\nENTER to return to main menu.");
            Console.ReadLine();
        }

        static void PrintStudents(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("===== Print out student list =====");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nENTER to return to main menu.");
            Console.ReadLine();
        }

        static Student GetNewStudentFromUser()
        {
            string firstName = "";
            string lastName = "";
            int birthYear = 0;
            int birthMonth = 0;
            int birthDay = 0;
            DateOnly birthDate = new DateOnly();
            string course = "";

            Console.Clear();
            Console.WriteLine("===== Create new student =====");
            while (firstName.Length == 0)
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine().Trim();
            }
            while (lastName.Length == 0)
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine().Trim();
            }
            while(birthDate.Year == 1)
            {
                birthYear = 0;
                birthMonth = 0;
                birthDay = 0;
                while (birthYear <= 0)
                {
                    Console.Write("Birth year: ");
                    Int32.TryParse(Console.ReadLine(), out birthYear);
                }
                while (birthMonth <= 0 || birthMonth > 12)
                {
                    Console.Write("Birth month: ");
                    Int32.TryParse(Console.ReadLine(), out birthMonth);
                }
                while (birthDay <= 0 || birthDay > 31)
                {
                    Console.Write("Birth day: ");
                    Int32.TryParse(Console.ReadLine(), out birthDay);
                }
                try
                {
                    birthDate = new DateOnly(birthYear, birthMonth, birthDay);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (course.Length == 0)
            {
                Console.Write("Course: ");
                course = Console.ReadLine().Trim();
            }

            Console.WriteLine("Adding new student.");

            Console.WriteLine("\nENTER to return to main menu.");
            Console.ReadLine();

            return new Student(firstName, lastName, birthDate, course);
        }
    }
}
