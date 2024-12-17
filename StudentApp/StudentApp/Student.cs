namespace StudentApp
{
    internal class Student
    {
        public static int Counter = 0;
        public string Name { get; private set; }
        public int Age { get; set; }
        public int StudentId { get; set; }

        public List<Student> StudentList { get; private set; }
        public List<Subject> OngoingCourses { get; private set; }
        public List<Subject> FinishedCourses { get; private set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            StudentId = Counter++;
            OngoingCourses = new List<Subject>();
            FinishedCourses = new List<Subject>();
        }

        public List<Student> MakeStudentsList()
        {
            StudentList =
            [
                new("Jim", 23),
                new("Anna", 29),
                new("Joe", 22),
                new("Christine", 29),
                new("Tim", 23),
                new("Kris M", 26),
                new("Hannah", 25),
                new("Magbula", 41),
            ];
            return StudentList;
        }

        public Student()
        {

        }
        public void CurrentCourses(Subject course)
        {
            if (!OngoingCourses.Contains(course))
            {
                OngoingCourses.Add(course);
                Console.WriteLine($"{Name} registered for {course.SubjectName}.");
            }
            else
            {
                Console.WriteLine($"{Name} is already registered for {course.SubjectName}.");
            }
        }

        public void ShowStudent()
        {
            Console.WriteLine($"\nStudent: {Name}\n Age: {Age}\n Student Program: \n Id: {StudentId}");
        }
        public void ShowAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name} \nID: {student.StudentId}\n");
            }
        }

        public List<Student> GetStudentList()
        {
            return StudentList;
        }
    }

}
