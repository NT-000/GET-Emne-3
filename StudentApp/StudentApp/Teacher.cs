namespace StudentApp
{
    internal class Teacher
    {
        private List<Student> Students { get; set; }
        private List<Subject> Courses { get; set; }
        private List<StudentGrades> Grades { get; set; }

        public Teacher(List<Student> students, List<Subject> subjects, List<StudentGrades> grades)
        {
            Students = students;
            Courses = subjects;
            Grades = grades;
        }
        public void TeacherMenu()
        {
            bool isTeacher = true;
            while (isTeacher)
            {
                Console.Clear();
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add students");
                Console.WriteLine("2. Add courses");
                Console.WriteLine("3. Assign grades");
                Console.WriteLine("4. Main Menu");
                Console.WriteLine("5. Show Students and Grades");
                var inputTeacher = Console.ReadLine();
                switch (inputTeacher)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add student");

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Create a course");
                        Console.WriteLine("Enter course name: ");
                        string courseName = Console.ReadLine();
                        Console.WriteLine("How many credits: ");
                        int creds = int.Parse(Console.ReadLine());
                        Subject addCourse = new Subject(courseName, creds);
                        Courses.Add(addCourse);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Add grades");
                        Console.WriteLine("Student id:");
                        int studentIdGrade = int.Parse(Console.ReadLine());
                        Console.WriteLine("Course-Id:");
                        int courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Grade:");
                        int grade = int.Parse(Console.ReadLine());
                        var currentStudent = Students.Find(student => student.StudentId == studentIdGrade);
                        var currentClass = Courses.Find(course => course.SubjectCode == courseId);

                        if (currentStudent != null || currentClass != null || grade != null)
                        {
                            StudentGrades newGrade = new StudentGrades(currentStudent, currentClass, grade);
                            Grades.Add(newGrade);
                            CompleteCourse(currentStudent, currentClass);
                        }
                        Console.WriteLine($"Student: {currentStudent.Name}, Subject: {currentClass.SubjectName}, Grade: {grade}");

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Main menu");
                        isTeacher = false;
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("The grades:");
                        ShowAllGrades();
                        break;
                }

                void ShowAllGrades()
                {

                    if (Grades.Count == 0)
                    {
                        Console.WriteLine("No grades to display.");
                        return;
                    }
                    foreach (var grade in Grades)
                    {
                        Console.WriteLine($"Student: {grade.Student.Name} Class:{grade.Subject.SubjectName} Grade:{grade.Grade}\n ");
                    }

                }

                void CompleteCourse(Student currentStudent, Subject currentClass)
                {
                    currentStudent.OngoingCourses.Remove(currentClass);
                    currentStudent.FinishedCourses.Add(currentClass);
                    Console.WriteLine($"{currentStudent} just finished {currentClass}\n");
                }

            }

        }
    }
}

