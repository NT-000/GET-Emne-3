using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Subject
    {
        private int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        private int Credits { get; set; }

        public List<Subject> Subjects = new List<Subject>();

        public Subject(int subjectCode, string subjectName, int credits)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Credits = credits;
        }

        public void OutputInfo()
        {

            Console.WriteLine($"Course:{SubjectName} Course-Id:{SubjectCode} Credits: {Credits}");
        }

        public void AddSubject(int subjectCode, string subjectName, int credits)
        {



            Subjects.Add(new Subject(subjectCode, subjectName, credits
            ));
            Console.WriteLine("Course added!");

        }

    }
}
