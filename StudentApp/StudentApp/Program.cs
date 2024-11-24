using System;
using System.Diagnostics;
namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to this student application");
            var student1 = Run(out var student2, out var student3, out var student4, out var bachelorArts, out var bachelorMusic, out var bachelorAth, out var bachelorPsy, out var grade, out var grade2, out var grade3, out var grade4, out var students, out var subjects, out var Grade);


            bool isMenu = true;

            while (isMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nMenu");
                Console.ResetColor();
                Console.WriteLine("1. Teacher menu");
                Console.WriteLine("2. Show Data");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose one of the options");
                var inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add students, courses and assign grades");
                        Teacher menu = new Teacher(students, subjects, Grade);
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

        public static Student Run(out Student student2, out Student student3, out Student student4, out Subject bachelorArts,
            out Subject bachelorMusic, out Subject bachelorAth, out Subject bachelorPsy, out StudentGrades grade,
            out StudentGrades grade2, out StudentGrades grade3, out StudentGrades grade4, out List<Student> students, out List<Subject> subjects,
            out List<StudentGrades> Grade)
        {
            Student student1 = new("Jim", 23, "Bachelor of Arts", 1);
            student2 = new("Anna", 29, "Bachelor of Music", 2);
            student3 = new("Joe", 22, "", 3);
            student4 = new("Christine", 29, "Bachelor of Music", 4);
            bachelorArts = new(1, "Bachelor of Arts", 180);
            bachelorMusic = new(2, "Bachelor of Music", 180);
            bachelorAth = new(3, "Bachelor Athletics", 180);
            bachelorPsy = new(4, "Bachelor of Psychology", 180);
            grade = new StudentGrades(student1, bachelorMusic, 4);
            grade2 = new StudentGrades(student1, bachelorArts, 5);
            grade3 = new StudentGrades(student2, bachelorArts, 6);
            grade4 = new StudentGrades(student2, bachelorArts, 5);
            students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            subjects = new List<Subject>();
            subjects.Add(bachelorArts);
            subjects.Add(bachelorArts);
            subjects.Add(bachelorAth);
            subjects.Add(bachelorPsy);
            Grade = new List<StudentGrades>();
            Grade.Add(grade);
            Grade.Add(grade2);
            Grade.Add(grade3);
            Grade.Add(grade4);
            return student1;
        }
    }
}
