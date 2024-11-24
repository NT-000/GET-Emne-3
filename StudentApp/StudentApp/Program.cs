using System;
using System.Diagnostics;
namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to this student application");
            List<Student> students = new List<Student>();
            List<Subject> subjects = new List<Subject>();
            List<StudentGrades> grades  = new List<StudentGrades>();
            Subject bachelorArts = new(1, "Bachelor of Arts", 180);
            Subject bachelorMusic = new(2, "Bachelor of Music", 180);
            Student student1 = new("Jim", 23, "Bachelor of Arts", 1);
            Student student2 = new("Anna", 29, "Bachelor of Music", 2);
            StudentGrades grade = new StudentGrades(student1, bachelorMusic, 4);
            StudentGrades grade2 = new StudentGrades(student1, bachelorArts, 5);
            StudentGrades grade3 = new StudentGrades(student2, bachelorArts, 6);
            StudentGrades grade4 = new StudentGrades(student2, bachelorArts, 5);

            bool isMenu = true;

            while (isMenu)
            {
                Console.WriteLine("\n Options");
                Console.WriteLine("1.Teacher menu");
                Console.WriteLine("2. Show Data");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose one of the options");
                var inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add students, courses and assign grades");
                        Teacher menu = new Teacher();
                        menu.TeacherMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Show data");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Shutting down...");
                        isMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Only 1,2 or to exit, 3");
                        break;

                }
            }


            bachelorArts.OutputInfo();
            bachelorMusic.OutputInfo();
            student1.showStudent();
            student2.showStudent();
        }
    }
}
