using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class testSubject
    {
        public int SchoolSubjectId { get; private set; }
        public string SubjectName { get; private set; }
        public string SubjectDescription { get; private set; }
        public int Credits { get; private set; }
        private List<testSubject> Subjects { get; set; }

        public testSubject(int schoolSubjectId, string subjectName, string subjectDescription, int credits)
        {
            SchoolSubjectId = schoolSubjectId;
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
            Credits = credits;
        }

        public void InitializeSubjects()
        {
            Subjects =
            [
                new testSubject(1,"Gym", "Physical education", 45),
                new testSubject(2,"Math", "Physical education", 45),
                new testSubject(3,"Biology", "Physical education", 45),

            ];
        }
    }
}
