namespace StudentApp
{
    internal class Subject
    {
        static int counterClass = 0;
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }



        public Subject(string subjectName, int credits)
        {
            SubjectCode = counterClass++;
            SubjectName = subjectName;
            Credits = credits;
        }

    }
}
