namespace StudentApp__new_version
{
    internal class Menu
    {

        public Menu()
        {

        }


        public void StartMenu(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, GradeManager gradeManager, StudentManager studentManager)
        {
            bool isRunning = true;
            var subjectManager = new SubjectManager();
            while (true)
            {
                Console.WriteLine($"1.See {selectedUser.GetLoggedIn().Name}'s grades");
                Console.WriteLine("2.Enroll to class");
                Console.WriteLine("3.Logout");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        gradeManager.ShowLoggedInUserGrades(selectedUser);
                        break;
                    case '2':
                        Console.Clear();
                        studentManager.EnlistToClass(subjectManager.GetSchoolSubjects(), selectedUser);
                        break;
                    case '3':
                        Console.Clear();
                        LogOutUser(subject, grade, student, selectedUser, gradeManager, studentManager);
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }

        public void StartMenuTeacher(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, GradeManager gradeManager, StudentManager studentManager)
        {
            bool isRunning = true;
            var subjectManager = new SubjectManager();
            var teacherManager = new TeacherManager();
            while (true)
            {
                Console.WriteLine("1.See all students");
                Console.WriteLine("2.Show all grades");
                Console.WriteLine("3.Grade students");
                Console.WriteLine("4.Enroll student to class");
                Console.WriteLine("5.Log out\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        studentManager.PrintUsers(gradeManager);
                        break;
                    case '2':
                        Console.Clear();
                        gradeManager.ShowGrades();
                        break;
                    case '3':
                        Console.Clear();
                        gradeManager.AddGrade(studentManager, student);
                        break;
                    case '4':
                        Console.Clear();
                        teacherManager.EnlistToClass(subjectManager.GetSchoolSubjects(), studentManager.GetUsers());
                        break;
                    case '5':
                        Console.Clear();
                        LogOutUser(subject, grade, student, selectedUser, gradeManager, studentManager);
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }
        public void LogInView(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, GradeManager gradeManager, StudentManager studentManager)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register new user");
                Console.WriteLine("Or shut it down");
                switch (Console.ReadKey(intercept: true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        LoginUser(subject, grade, student, selectedUser, gradeManager, studentManager);
                        break;
                    case '2':
                        Console.Clear();
                        RegisterUser(studentManager);
                        break;
                    default:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        public void LoginUser(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, GradeManager gradeManager, StudentManager studentManager)
        {
            Console.WriteLine("Enter your id");
            int inputId = Convert.ToInt32(Console.ReadLine());
            if (inputId == null)
            {
                Console.WriteLine("Enter valid password");
            }
            Console.WriteLine("Enter your password");
            string inputPass = Console.ReadLine();
            if (inputPass == null)
            {
                Console.WriteLine("Enter valid password");
                ;
            }

            var foundUser = studentManager.GetUsers().Find(user => user.Id == inputId && inputPass == user.Password);
            if (foundUser != null)
            {
                Console.Clear();
                Console.WriteLine($"Login is successful, welcome {foundUser.Name}!\n");
                selectedUser.SetLoggedInStudent(foundUser);

                if (foundUser.Type == "Student")
                {
                    StartMenu(subject, grade, student, selectedUser, gradeManager, studentManager);
                }
                else if (foundUser.Type == "Teacher")
                {
                    StartMenuTeacher(subject, grade, student, selectedUser, gradeManager, studentManager);
                }
            }
            else
            {
                Console.WriteLine("Invalid log in");
            }
        }

        public void RegisterUser(StudentManager studentManager)
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new password");
            string pass = Console.ReadLine();
            int id = studentManager.GetUsers().Count + 1;

            studentManager.GetUsers().Add(new Student(id, name, age, pass));
            Console.WriteLine($"{name} was just added");

        }

        public void LogOutUser(SchoolSubject subject, Grade grade, Student student, SelectedUser selectedUser, GradeManager gradeManager, StudentManager studentManager)
        {
            selectedUser.SetLoggedInStudent(null);
            Console.WriteLine("User has been logged out successfully.");
            LogInView(subject, grade, student, selectedUser, gradeManager, studentManager);

        }
    }
}
