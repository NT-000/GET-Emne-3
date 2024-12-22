namespace StudentApp__new_version
{
    internal class Grade
    {
        public int StudentGrade { get; private set; }
        public Student Student { get; private set; }
        public SchoolSubject Subject { get; private set; }

        public Grade(int studentGrade, IUser student, SchoolSubject subject)
        {
            StudentGrade = studentGrade;
            Student = (Student)student;
            Subject = subject;
        }

        public Grade()
        {
        }
    }
}
