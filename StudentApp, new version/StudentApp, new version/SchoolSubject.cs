using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    public class SchoolSubject
    {
        public int SchoolSubjectId { get;private set; }
        public string SubjectName { get;private set; }
        public string SubjectDescription { get;private set; }
        public int Credits { get;private set; }

        public List<SchoolSubject> EnrolledStudentsList { get; private set; } = new List<SchoolSubject>();

        public List<SchoolSubject> AvailableSchoolSubjects { get; set; }

        public SchoolSubject(int schoolSubjectId, string subjectName, string subjectDescription, int credits)
        {
            SchoolSubjectId = schoolSubjectId;
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
            Credits = credits;
            EnrolledStudentsList = new List<SchoolSubject>();
        }


        public List<SchoolSubject> GetSchoolSubjectList ()
        {
            return EnrolledStudentsList;
        }


        public SchoolSubject()
        {
            AvailableSchoolSubjects = new List<SchoolSubject> {
                new Gym(), new Math(), new Biology()};
        }
    }

    internal class Gym : SchoolSubject
    {
        public List<SchoolSubject> GymStudentsList { get; private set; } = new List<SchoolSubject>();
        public Gym() : base(1,"Gym", "Physical education", 45)
        {
            GymStudentsList = new List<SchoolSubject>();
        }
    }
    internal class Math : SchoolSubject
    {
        public List<SchoolSubject> MathStudentsList { get; private set; } = new List<SchoolSubject>();
        public Math() : base(2, "Math", "Simple math for beginners.", 45)
        {
            MathStudentsList = new List<SchoolSubject>();
        }
    }
    internal class Biology : SchoolSubject
    {
        public List<SchoolSubject> BiologyStudentsList { get; private set; } = new List<SchoolSubject>();
        public Biology() : base(3, "Biology", "Physical education", 45)
        {
            BiologyStudentsList = new List<SchoolSubject>();
        }
    }
}
