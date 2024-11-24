using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudentProgram { get; set; }
        public int StudentId { get; set; }


        public Student(string name, int age, string studentProgram, int studentId)
        {
            Name = name;
            Age = age;
            StudentProgram = studentProgram;
            StudentId = studentId;
        }


        public void showStudent()
        {
            Console.WriteLine($"\nStudent: {Name}\n Age: {Age}\n Student Program: {StudentProgram}\n Id: {StudentId}");
        }
    }

}
