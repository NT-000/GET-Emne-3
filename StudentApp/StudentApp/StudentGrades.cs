namespace StudentApp
{
    internal class StudentGrades
    {

        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public int Grade { get; set; }



        public StudentGrades(Student currentStudent, Subject subject, int grade)
        {
            Student = currentStudent;
            Subject = subject;
            Grade = grade;
        }
    }

}
