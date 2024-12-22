namespace StudentApp__new_version;

internal class GradeManager
{
    public List<Grade> Grades { get; private set; }
    public List<IUser> _Students { get; private set; }
    public List<SchoolSubject> AvailableSchoolSubjects { get; private set; }

    public GradeManager()
    {

    }

    public GradeManager(List<IUser> students, List<SchoolSubject> availableSchoolSubjects)
    {
        _Students = students;
        AvailableSchoolSubjects = availableSchoolSubjects;
        InitializeGrades(students, availableSchoolSubjects);
    }

    public void InitializeGrades(List<IUser> students, List<SchoolSubject> subjects)
    {
        Student student1 = (Student)students.Find(s1 => s1.Id == 1);
        student1.FinishedSchoolSubjects.Add(new Gym());

        Student student2 = (Student)students.Find(s1 => s1.Id == 2);
        student2.FinishedSchoolSubjects.Add(new Math());

        var student3 = (Student)students.Find(s2 => s2.Id == 3);
        student3.FinishedSchoolSubjects.Add(new Math());
        student3.FinishedSchoolSubjects.Add(new Biology());

        var student5 = (Student)students.Find(s4 => s4.Id == 5);
        student5.FinishedSchoolSubjects.Add(new Gym());
        student5.FinishedSchoolSubjects.Add(new Biology());

        var student6 = (Student)students.Find(s4 => s4.Id == 6);
        student6.FinishedSchoolSubjects.Add(new Gym());

        Grades =
        [
            new Grade(5, students[0],subjects[0]),
            new Grade(6, students[1],subjects[1]),
            new Grade(3, students[2],subjects[1]),
            new Grade(5, students[2],subjects[2]),
            new Grade(2, students[4],subjects[2]),
            new Grade(3, students[4],subjects[0]),
            new Grade(4, students[5],subjects[0])
        ];
    }

    public void ShowGrades()
    {
        Console.WriteLine("Here's all grades");
        foreach (var grade in Grades)
        {
            Console.WriteLine($"Name:{grade.Student.Name} Class:{grade.Subject.SubjectName} Grade:{grade.StudentGrade}");
        }
    }

    public List<Grade> GetGrades()
    {
        return Grades;
    }

    public void ShowLoggedInUserGrades(SelectedUser selectedUser)
    {
        Console.WriteLine($"Here is your grades {selectedUser.GetLoggedIn().Name}");
        var userGrades = Grades.Where(user => user.Student.Id == selectedUser.GetLoggedIn().Id).ToList();
        foreach (var g in userGrades)
        {
            Console.WriteLine($"{g.Student.Name} {g.Subject.SubjectName} {g.StudentGrade}");
        }
    }

    public void AddGrade(StudentManager studentManager, Student student)
    {
        var _studentList = studentManager.GetUsers();
        Console.WriteLine("Grade Student");
        foreach (var user in _studentList)
        {
            Console.WriteLine($"{user.Id}.{user.Name}");
        }
        var index = Convert.ToInt32(Console.ReadLine());
        var selectedStudent = _studentList[index - 1];
        Console.WriteLine($"You chose {selectedStudent.Name}");
        if (selectedStudent is Student checkStudent)
        {
            foreach (var s in checkStudent.OngoingSubjects)
            {
                Console.WriteLine($"{s.SchoolSubjectId}.{s.SubjectName}\nInfo:{s.SubjectDescription}\nCredits: {s.Credits}");
            }


            Console.WriteLine("Select subject to grade");
            int index2 = Convert.ToInt32(Console.ReadLine());
            var subject = checkStudent.OngoingSubjects[index2 - 1];
            Console.WriteLine($"Add grade for {student.Name} in {subject.SubjectName}");
            int grade = Convert.ToInt32(Console.ReadLine());

            Grades.Add(new Grade(grade, checkStudent, subject));
            checkStudent.OngoingSubjects.Remove(subject);
            checkStudent.FinishedSchoolSubjects.Add(subject);
            Console.WriteLine($"{grade} added for {student.Name} in class {subject.SubjectName}!");
        }
    }

}