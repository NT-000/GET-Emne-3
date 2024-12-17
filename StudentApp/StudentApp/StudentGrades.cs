namespace StudentApp
{
    internal class StudentGrades
    {

        public Student Student { get; private set; }
        public Subject Subject { get; private set; }
        public int Grade { get; private set; }

        private List<StudentGrades> _gradesList { get; set; }



        public StudentGrades(Student currentStudent, Subject subject, int grade)
        {
            Student = currentStudent;
            Subject = subject;
            Grade = grade;
            MakeGradesList();
        }
        public List<StudentGrades> MakeGradesList()
        {
            _gradesList =
            [
                new (student1, bachelorMusic, 4),
                new (student1, bachelorArts, 5),
                new (student2, bachelorArts, 6),
                new (student2, bachelorPsy, 5),
            ];
        }
    }

}
