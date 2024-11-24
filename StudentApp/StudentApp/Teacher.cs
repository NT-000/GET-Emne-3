using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Teacher
    {
        private List<Student> Students { get; set; }
        private List<Subject> Courses { get; set; }
        private List<StudentGrades> Grades { get; set; }

        public Teacher(List<Student> students, List<Subject> subjects, List<StudentGrades> grades)
        {
            Students = students;
            Courses = subjects;
            Grades = grades;
        }
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
                Console.WriteLine("5. Show Students and Grades");
                var inputTeacher = Console.ReadLine();
                switch (inputTeacher)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add student");
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter age of student: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Class to enlist: ");
                        string course = Console.ReadLine();
                        Console.WriteLine("Enter new student-id: ");
                        int studentId = int.Parse(Console.ReadLine());
                        Student addStudent = new Student(name, age, course, studentId);
                        Students.Add(addStudent);

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Add course");
                        Console.WriteLine("Enter course-id: ");
                        int courseId1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter course name: ");
                        string courseName = Console.ReadLine();
                        Console.WriteLine("How many credits: ");
                        int creds = int.Parse(Console.ReadLine());
                        Subject addCourse = new Subject(courseId1, courseName, creds);
                        Courses.Add(addCourse);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Add grades");
                        Console.WriteLine("Student id:");
                        int studentIdGrade = int.Parse(Console.ReadLine());
                        Console.WriteLine("Course-Id:");
                        int courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Grade:");
                        int grade = int.Parse(Console.ReadLine());
                        var currentStudent = Students.Find(student => student.StudentId == studentIdGrade);
                        var classId = Courses.Find(course => course.SubjectCode == courseId);

                        StudentGrades newGrade = new StudentGrades(currentStudent, classId, grade);
                        Grades.Add(newGrade);


                        Console.WriteLine($"Student: {currentStudent.Name}, Subject: {classId.SubjectName}, Grade: {grade}");

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Main menu");
                        isTeacher = false;
                        break;
                    case "5":
                        Console.WriteLine("The grades:");
                        ShowAllGrades();


                        
                        break;

                }
                 void ShowAllGrades()
                {

                    if (Grades.Count == 0)
                    {
                        Console.WriteLine("No grades available to display.");
                        return;
                    }

                    foreach (var grade in Grades)

                    {

                        Console.WriteLine($"Student: {grade.Student.Name} Class:{grade.Subject.SubjectName} Grade:{grade.Grade} ");
                    }

                }
    }
        }
    }
}
