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


        //public void ShowGrades(string name, string subject, int grade)
        //{
        //    if (Student == null || Subject == null)
        //    {
        //        Console.WriteLine("Missing student or subject info.");
        //        return;
        //    }
        //    Console.WriteLine($"Student: {name}, Subject: {Subject.SubjectName}, Grade: {grade}");
        //}


    }

}
