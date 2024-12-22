namespace StudentApp__new_version
{
    internal class Student : IUser
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public List<SchoolSubject> OngoingSubjects { get; private set; }
        public List<SchoolSubject> FinishedSchoolSubjects { get; private set; }
        public string Type { get; private set; }
        public string Password { get; set; }

        public Student(int id, string name, int age, string password)
        {
            Id = id;
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

        }

        public int GetStudentId()
        {
            return Id;
        }

        public List<SchoolSubject> GetOngoingList()
        {
            return OngoingSubjects;
        }

        public List<SchoolSubject> GetFinishedList()
        {
            return FinishedSchoolSubjects;
        }



    }

}
