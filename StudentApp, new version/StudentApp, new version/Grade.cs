using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class Grade
    {   
        public int StudentGrade { get; private set; }
        public Student Student { get; private set; }
        public SchoolSubject Subject { get; private set; }

        public List<Grade> Grades { get; private set; }

        public Grade(List<Student> students, List<SchoolSubject> subjects)
        {
            InitializeGrades(students, subjects);
        }

        public Grade(int studentGrade, Student student, SchoolSubject subject)
        {
            StudentGrade = studentGrade;
            Student = student;
            Subject = subject;
        }

        public void InitializeGrades(List<Student> students, List<SchoolSubject> subjects)
        {
            Grades =
            [
                new Grade(5, students[0],subjects[0]),
                new Grade(6, students[1],subjects[1]),
                new Grade(3, students[2],subjects[1]),
                new Grade(5, students[2],subjects[2]),
                new Grade(2, students[4],subjects[2]),
                new Grade(3, students[4],subjects[0]),
                new Grade(4, students[5],subjects[0])
            ];
        }

        public void ShowGrades()
        {
            Console.WriteLine("Here's all grades");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"Name:{grade.Student.Name} Class:{grade.Subject.SubjectName} Grade:{grade.StudentGrade}");  
            }
        }

        public void ShowLoggedInUserGrades(SelectedUser selectedUser)
        {
            Console.WriteLine($"Here is your grades {selectedUser.GetLoggedIn().Name}");
            var userGrades = Grades.Where(user => user.Student.StudentId == selectedUser.GetLoggedIn().StudentId);
            foreach (var g in userGrades)
            {
                Console.WriteLine($"{g.Student.Name} {g.Subject.SubjectName} {g.StudentGrade}");
            }
        }

        public void AddGrade(List<Student> _studentList)
        {
            Console.WriteLine("Grade Student");
            foreach (var s in _studentList)
            {
                Console.WriteLine($"{s.GetStudentId()}.{s.Name}");
            }
            var index = Convert.ToInt32(Console.ReadLine());
            var student = _studentList[index];
            Console.WriteLine($"You chose {student.Name}");
            foreach (var s in student.OngoingSubjects)
            {
                Console.WriteLine($"{s.SchoolSubjectId}{s.SubjectName} {s.SubjectDescription} {s.Credits}");
            }

            Console.WriteLine("Select subject to grade");
            int index2 = Convert.ToInt32(Console.ReadLine());
            var subject = student.OngoingSubjects[index2 - 1];
            Console.WriteLine($"Add grade for {student.Name} in {subject.SubjectName}");
            int grade = Convert.ToInt32(Console.ReadLine());

            Grades.Add(new Grade(grade, student, subject));
            student.OngoingSubjects.Remove(subject);
            student.FinishedSchoolSubjects.Add(subject);
            Console.WriteLine($"{grade} added for {student.Name} in class {subject.SubjectName}!");
        }

    }
}
