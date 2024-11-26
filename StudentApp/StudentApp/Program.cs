namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, welcome to this student application");
            Student student1 = new("Jim", 23);
            Student student2 = new("Anna", 29);
            Student student3 = new("Joe", 22);
            Student student4 = new("Christine", 29);
            Student student5 = new("Tim", 23);
            Student student6 = new("Kris M", 26);
            Student student7 = new("Hannah", 25);
            Student student8 = new("Magbula", 41);
            Subject bachelorArts = new("Bachelor of Arts", 180);
            Subject bachelorMusic = new("Bachelor of Music", 180);
            Subject bachelorAth = new("Bachelor Athletics", 180);
            Subject bachelorPsy = new("Bachelor of Psychology", 180);
            Subject masterArts = new Subject("Master of Arts", 120);
            Subject masterMusic = new Subject("Master of Music", 120);
            Subject masterAthletics = new Subject("Master of Athletics", 120);
            Subject masterPsy = new Subject("Master of Psychology", 120);
            StudentGrades grade = new StudentGrades(student1, bachelorMusic, 4);
            StudentGrades grade2 = new StudentGrades(student1, bachelorArts, 5);
            StudentGrades grade3 = new StudentGrades(student2, bachelorArts, 6);
            StudentGrades grade4 = new StudentGrades(student2, bachelorPsy, 5);
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            students.Add(student6);
            students.Add(student7);
            students.Add(student8);
            List<Subject> subjects = new List<Subject>();
            subjects.Add(bachelorArts);
            subjects.Add(bachelorMusic);
            subjects.Add(bachelorAth);
            subjects.Add(bachelorPsy);
            subjects.Add(masterArts);
            subjects.Add(masterMusic);
            subjects.Add(masterAthletics);
            subjects.Add(masterPsy);

            List<StudentGrades> Grade = new List<StudentGrades>();
            Grade.Add(grade);
            Grade.Add(grade2);
            Grade.Add(grade3);
            Grade.Add(grade4);


            bool isMenu = true;

            while (isMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nMenu");
                Console.ResetColor();
                Console.WriteLine("1. Teacher menu");
                Console.WriteLine("2. Student menu");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose one of the options");
                var inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add students, courses and assign grades");
                        Teacher menu = new Teacher(students, subjects, Grade);
                        menu.TeacherMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Log in with your ID");
                        Student displayStudents = new Student();
                        displayStudents.ShowAllStudents(students);
                        var inputLogin = int.Parse(Console.ReadLine());
                        var currentStudent = students.Find(student => student.StudentId == inputLogin);
                        Console.WriteLine($"{currentStudent.Name}");

                        StudentView menu2 = new StudentView(students, subjects, Grade);
                        menu2.StudentMenu(currentStudent.StudentId);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Shutting down...");
                        isMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Only 1,2 or to exit, 3");
                        break;

                }
            }
        }
    }
}
