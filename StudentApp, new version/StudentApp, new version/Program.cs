
using StudentApp__new_version;

var teacher = new Teacher();
var subject = new SchoolSubject();
var student = new Student();
var grade = new Grade(student.GetStudentList(), subject.AvailableSchoolSubjects);
var menu = new Menu();
var selectedUser = new SelectedUser();

teacher.InitializingTeacher();

Run();
void Run()
{
    menu.LogInView(subject,grade, student, selectedUser, teacher);
}

