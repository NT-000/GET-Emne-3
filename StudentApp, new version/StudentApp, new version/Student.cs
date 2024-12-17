using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class Student
    {   
        public static int IdCounter = 1;
        public int StudentId { get; private set; }
        public string Name { get; private set; }
        public int Age { get;private set; }
        public List<SchoolSubject> OngoingSubjects { get; private set; }
        public List<SchoolSubject> FinishedSchoolSubjects { get; private set; }
        public string Type { get; private set; }
        public List<Student> StudentList { get; private set; }
        public string Password { get; set; }

        public Student(string name, int age, string password)
        {
            StudentId = IdCounter++;
            Name = name;
            Age = age;
            OngoingSubjects = new List<SchoolSubject>
            {
                new Gym()
            };
            FinishedSchoolSubjects = new List<SchoolSubject>();
            Type = "Student";
            Password = password;
        }

        public Student()
        {
            StudentList = 
            [
                new("Jim", 23, "123"),
                new("Anna", 29,"123"),
                new("Joe", 22, "123"),
                new("Christine", 29, "123"),
                new("Tim", 23, "123"),
                new("Kris M", 26, "123"),
                new("Hannah", 25, "123"),
                new("Magbula", 41, "123"),
            ];
        }


        public Student(string name, int age, List<SchoolSubject> ongoingSubjects, string password)
        {
            StudentId = IdCounter++;
            Name = name;
            Age = age;
            OngoingSubjects = ongoingSubjects;
            FinishedSchoolSubjects = new List<SchoolSubject>();
            Password = password;
        }

        public List<Student> GetStudentList()
        {
            return StudentList;
        }
        public void PrintStudents()
        {
            Console.WriteLine("Students:");
            foreach (var s in StudentList)
            {
                Console.WriteLine($"{s.StudentId}.{s.Name}");
            }

        }

        public int GetStudentId()
        {
            return StudentId;
        }

        public void EnlistToClass(List<Student> studentList, List<SchoolSubject> subjectList)
        {
            Console.WriteLine($"Add student to a class");
            foreach (var s in studentList)
            {
                Console.WriteLine($"{s.GetStudentId()}.{s.Name}");
            }

            Console.WriteLine("Select a student to enlist");
            int inputIndex = Convert.ToInt32(Console.ReadLine());
            var student = studentList[inputIndex];
            Console.WriteLine($"You chose {student.Name}");
            Console.WriteLine("Select a subject");
            foreach (var s in subjectList)
            {
                Console.WriteLine($"{s.SchoolSubjectId}.{s.SubjectName}");
            }
            int inputIndex2 = Convert.ToInt32(Console.ReadLine());
            var subject = subjectList[inputIndex2];
            Console.WriteLine($"You chose {subject.SubjectName}");

            student.OngoingSubjects.Add(subject);

        }
    }

}
