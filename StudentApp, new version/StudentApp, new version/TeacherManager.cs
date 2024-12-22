namespace StudentApp__new_version
{
    internal class TeacherManager
    {
        public TeacherManager()
        {

        }
        public void EnlistToClass(List<SchoolSubject> subjectList, Student student, List<IUser> users)
        {
            Console.WriteLine($"Add student to a class");
            foreach (var s in users)
            {
                Console.WriteLine($"{s.Id}.{s.Name}");
            }

            Console.WriteLine("Select a student to enlist");
            int inputId = Convert.ToInt32(Console.ReadLine());
            if (inputId == null)
            {
                Console.WriteLine("Invalid Id");
            }
            var chosenStudent = users.Find(u => u.Id == inputId);
            Console.WriteLine($"You chose {chosenStudent.Name}");
            Console.WriteLine("Select a subject");
            foreach (var s in subjectList)
            {
                Console.WriteLine($"{s.SchoolSubjectId}.{s.SubjectName}");
            }
            int inputId2 = Convert.ToInt32(Console.ReadLine());
            if (inputId2 == null)
            {
                Console.WriteLine("Invalid Id");
            }
            var chosenSubject = subjectList.Find(s => s.SchoolSubjectId == inputId2);
            Console.WriteLine($"You chose {chosenSubject.SubjectName}");

            if (chosenStudent is Student checkStudent)
            {
                checkStudent.GetOngoingList().Add(chosenSubject);
            }
        }


    }
}
