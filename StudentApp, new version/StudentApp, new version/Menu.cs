using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class Menu
    {
        public Menu()
        {
            
        }

       public void StartMenu(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser)
        {
            bool isRunning = true;

            while (true)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("1.See all students");
                Console.WriteLine($"2.See {selectedUser.GetLoggedIn().Name}'s grades");
                Console.WriteLine("3.Show all grades");
                Console.WriteLine("4.Add grade");
                Console.WriteLine("5.Enroll to class");
                switch (Console.ReadKey(intercept: true).KeyChar)
                {
                    case '1':
                        student.PrintStudents();
                        break;
                    case '2':
                        grade.ShowLoggedInUserGrades(selectedUser);

                        break;
                    case '3':
                        grade.ShowGrades();
                        break;
                    case '4':
                        grade.AddGrade(student.GetStudentList());
                        break;
                    case '5':
                        student.EnlistToClass(student.GetStudentList(), subject.AvailableSchoolSubjects);
                        break;
                    case '6':
                        LogOutUser(selectedUser);
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }

        public void LogInView(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, Teacher teacher)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register new user");
                Console.WriteLine("Or shut it down");
                switch (Console.ReadKey(intercept: true).KeyChar)
                {
                    case '1':
                        LoginUser(subject, grade, student, selectedUser, teacher);
                        break;
                    case '2':
                        RegisterUser(student);
                        break;
                    default:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        public void LoginUser(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, Teacher teacher)
        {
            Console.WriteLine("Enter StudentId");
            int inputId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your password");
            string inputPass = Console.ReadLine();
            var foundStudent = student.StudentList.Find(user => user.StudentId == inputId && inputPass == user.Password);
            if (foundStudent != null)
            {
                Console.WriteLine($"Login is successful, welcome {foundStudent.Name}!");
                selectedUser.SetLoggedInStudent(foundStudent);
                StartMenu(subject, grade, student, selectedUser);
            }
            else
            {
                Console.WriteLine("Invalid log in");
            }
        }

        public void RegisterUser(Student student)
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new password");
            string pass = Console.ReadLine();

            student.StudentList.Add(new Student(name,age,pass));
            Console.WriteLine($"{name} was just added");

        }

        public void LogOutUser(SelectedUser selectedUser)
        {
            selectedUser.SetLoggedInStudent(null);
            Console.WriteLine("User has been logged out successfully.");
           
        }
    }
}
