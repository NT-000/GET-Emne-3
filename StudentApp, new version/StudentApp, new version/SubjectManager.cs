namespace StudentApp__new_version
{
    internal class SubjectManager
    {
        public List<SchoolSubject> schoolSubjects { get; private set; }

        public SubjectManager()
        {
            InitializeSubjects();
        }

        public void InitializeSubjects()
        {
            schoolSubjects = new List<SchoolSubject>
            {
                new Gym(), new Math(), new Biology()
            };
        }

        public List<SchoolSubject> GetSchoolSubjects()
        {
            return schoolSubjects;
        }
    }
}
