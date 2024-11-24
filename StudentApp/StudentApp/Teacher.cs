using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Teacher
    {
        public void TeacherMenu()
        {
            bool isTeacher = true;
            while (isTeacher)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add students");
                Console.WriteLine("2. Add courses");
                Console.WriteLine("3. Assign grades");
                Console.WriteLine("4. Main Menu");
                var inputTeacher = Console.ReadLine();
                switch (inputTeacher)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add student");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Add course");
                        Console.WriteLine("Enter course-id: ");
                        int courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter course name: ");
                        string courseName = Console.ReadLine();
                        Console.WriteLine("How many credits: ");
                        int creds = int.Parse(Console.ReadLine());
                        Subject addCourse = new Subject(courseId, courseName, creds);
                        addCourse.AddSubject(courseId, courseName, creds);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Add grades");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Main menu");
                        isTeacher = false;
                        break;
                }
            }
        }
    }
}
