﻿namespace StudentApp__new_version
{
    internal class StudentManager
    {
        public List<IUser> users { get; private set; }
        private string line = new ('_', 60);

        public StudentManager()
        {

            users =
            [
                new Student(1, "Jim", 23, "123"),
                new Student(2, "Anna", 29,"123"),
                new Student(3, "Joe", 22, "123"),
                new Student(4, "Christine", 29, "123"),
                new Student(5, "Tim", 23, "123"),
                new Student(6, "Kris M", 26, "123"),
                new Student(7, "Hannah", 25, "123"),
                new Student(8, "Magbula", 41, "123"),
                new Teacher(9, "Arne", "123"),
            ];
        }
        public void EnlistToClass(List<SchoolSubject> subjectList, SelectedUser selectedUser)
        {
            Console.WriteLine($"Enlist to a class, {selectedUser.GetLoggedIn().Name}");
            Console.WriteLine("Select a subject");
            if (selectedUser.GetLoggedIn() is Student user)
            {
                var availableClasses = subjectList.Where(c =>
                    !user.FinishedSchoolSubjects.Contains(c) && !user.OngoingSubjects.Contains(c)).ToList();
                if (availableClasses.Count == 0)
                {
                    Console.WriteLine("No available classes to enroll in.");
                    return;
                }
                foreach (var s in availableClasses)
                {
                    Console.WriteLine($"{s.SchoolSubjectId}.{s.SubjectName}");
                }
                int inputId2 = Convert.ToInt32(Console.ReadLine());
                if (inputId2 == null)
                {
                    Console.WriteLine("Invalid Id, try again");
                    return;
                }

                var chosenSubject = subjectList.Find(s => s.SchoolSubjectId == inputId2);
                Console.WriteLine($"You chose {chosenSubject.SubjectName}");
                user.GetOngoingList().Add(chosenSubject);
            }
            else
            {
                Console.WriteLine("...");
            }
        }

        public List<IUser> GetUsers()
        {
            return users;
        }
        public void PrintUsers(GradeManager gradeManager)
        {
            Console.WriteLine("Users:");
            Console.WriteLine($"{line}");
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name}");
            }

            Console.WriteLine($"{line}");
            Console.WriteLine("\nSelect a student to see grades");
            var input = Convert.ToInt32(Console.ReadLine());
            var student = (Student)users.Find(s => s.Id == input);

            Console.Clear();
            Console.WriteLine($"Info student: {student.Name}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAll passed classes");
            Console.ResetColor();
            Console.WriteLine($"{line}");
            var studentGrades = gradeManager.Grades.Where(g => g.Student.Id == student.Id).ToList();
            foreach (var g in studentGrades)
            {
                Console.WriteLine($"{g.Subject.SubjectName} - Grade:{g.StudentGrade}");
            }

            Console.WriteLine($"{line}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSummary\n");
            Console.ResetColor();
            Console.WriteLine($"Average grade: {CalculateGradeAverage(studentGrades)}");
            Console.WriteLine($"Total Credits: {CalculateTotalCredits(student)}");
            Console.WriteLine($"{line}\n");
    }
        public double CalculateGradeAverage(List<Grade> studentGrades)
        {
            double sum = 0;
            foreach (var g in studentGrades)
            {
                sum += g.StudentGrade;
            }

            return sum / studentGrades.Count;
        }

        public float CalculateTotalCredits(Student student)
        {
            float sum = 0;
            foreach (var score in student.FinishedSchoolSubjects)
            {
                sum += score.Credits;
            }

            return sum;
        }
    }
}
