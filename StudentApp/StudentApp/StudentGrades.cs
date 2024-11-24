using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class StudentGrades
    {
        public Student Student { get; set;}
        public Subject Subject { get; set;} 
        private int Grades { get; set; }

        public StudentGrades(Student student, Subject subject, int grades) 
        {
            Student = student;
            Subject = subject;
            Grades = grades;
        }

        public void ShowGrades()
        {
            Console.WriteLine($"Student: {Student.Name}, Subject. {Subject.SubjectName}, Grade: {Grades}");
        }
    }

}
