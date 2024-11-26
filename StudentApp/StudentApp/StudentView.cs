namespace StudentApp
{
    internal class StudentView
    {
        private List<Student> Students { get; set; }
        private List<Subject> Courses { get; set; }
        private List<StudentGrades> Grades { get; set; }

        public StudentView(List<Student> students, List<Subject> subjects, List<StudentGrades> grades)
        {
            Students = students;
            Courses = subjects;
            Grades = grades;
        }

        public void StudentMenu(int currentUserId)
        {
            var currentUser = Students.Find(student => student.StudentId == currentUserId);

            bool isStudentMenu = true;
            while (isStudentMenu)
            {
                Console.WriteLine($"Welcome, {currentUser.Name}!");
                Console.WriteLine("1. View your grades.");
                Console.WriteLine("2. View your info");
                Console.WriteLine("3.Go back to the main menu");
                Console.WriteLine("4.See ongoing classes");
                Console.WriteLine("5.See completed classes");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Here are your grades:");
                        ShowAllGrades(currentUserId);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enlist to class");
                        AddOngoingClass(currentUserId);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("See you later!");
                        isStudentMenu = false;
                        break;
                    case "4":
                        Console.Clear();
                        ShowOngoingClasses(currentUserId);
                        break;
                    case "5":
                        Console.Clear();
                        ShowCompletedClasses(currentUserId);
                        break;

                }
            }
            void AddOngoingClass(int currentUserId)
            {

                var student = Students.Find(s => s.StudentId == currentUserId);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }
                Console.Clear();
                Console.WriteLine($"Hello, {student.Name}:");
                Console.WriteLine("Enter Class ID to join:");
                ShowAllClasses();
                int courseId = int.Parse(Console.ReadLine());

                var chosenClass = Courses.Find(course => course.SubjectCode == courseId);
                if (chosenClass == null)
                {
                    Console.Clear();
                    Console.WriteLine("Class not found.");
                    return;
                }

                student.CurrentCourses(chosenClass);
            }
            void ShowAllClasses()
            {
                foreach (var subject in Courses)
                {
                    Console.WriteLine($"{subject.SubjectCode}Class: {subject.SubjectName}");
                }
            }
            void ShowAllGrades(int currentUserId)
            {

                float creditScore = CalculateCredits(currentUserId);
                double score = CalculateScore(currentUserId);
                var currentUserGrades = Grades.Where(grade => grade.Student.StudentId == currentUserId);
                if (Grades.Count == 0)
                {
                    Console.WriteLine("No grades to display.");
                    return;
                }

                foreach (var grade in currentUserGrades)

                {
                    Console.WriteLine($"Class: {grade.Subject.SubjectName} Grade: {grade.Grade}");

                }
                Console.WriteLine($"\nCourse credits:    {creditScore}");
                Console.WriteLine($"Average score:     {score}\n");
            }

            double CalculateScore(int currentUserId)
            {
                int sum = 0;
                var currentUserGrades = Grades.Where(grade => grade.Student.StudentId == currentUserId);
                foreach (var grade in currentUserGrades)

                {
                    sum += grade.Grade;
                }

                return (double)sum / currentUserGrades.Count();
            }

            float CalculateCredits(int currentUserId)
            {
                var currentStudent = Students.Find(student => student.StudentId == currentUserId);
                int sum = 0;
                foreach (var subjectCredits in currentStudent.FinishedCourses)
                {
                    sum += subjectCredits.Credits;
                }

                return sum;
            }
            void ShowOngoingClasses(int currentUserId)
            {
                var currentStudent = Students.Find(student => student.StudentId == currentUserId);
                foreach (var course in currentStudent.OngoingCourses)
                {
                    Console.Clear();
                    Console.WriteLine("Ongoing classes");
                    Console.WriteLine($"Course:{course.SubjectName} Course credits: {course.Credits}");
                }
            }
            void ShowCompletedClasses(int currentUserId)
            {
                var currentStudent = Students.Find(student => student.StudentId == currentUserId);
                foreach (var course in currentStudent.FinishedCourses)
                {
                    Console.Clear();
                    Console.WriteLine("Completed classes");
                    Console.WriteLine($"Course:{course.SubjectName} Course credits: {course.Credits}");
                    Console.WriteLine($"Total credits: {CalculateCredits(currentUserId)}\n");
                }
            }
        }
    }
}


//Husk -> flytte fra ongoing til finishedCourses !=grade