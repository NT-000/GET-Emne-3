
using StudentApp__new_version;

var teacher = new Teacher();
var subject = new SchoolSubject();
var student = new Student();

var menu = new Menu();
var selectedUser = new SelectedUser();
var studentManager = new StudentManager();
var subjectManager = new SubjectManager();
var grade = new Grade();
var gradeManager = new GradeManager(studentManager.GetUsers(), subjectManager.GetSchoolSubjects());

Run();
void Run()
{
    menu.LogInView(subject, grade, student, selectedUser, gradeManager, studentManager);
}
