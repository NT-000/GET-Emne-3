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
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        private int Credits { get; set; }



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


    }
}
