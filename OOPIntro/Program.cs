﻿namespace OOPIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Student student1 = new Student();
            student1.Name = "Fredrik";
            student1.Age = 51;
            Console.WriteLine($"{student1.Name} {student1.Age}");

            Student student2 = new Student();
            student2.Name = "Anna";
            student2.Age = 53;
            Console.WriteLine($"{student2.Name} {student2.Age}");
        }
    }
}
