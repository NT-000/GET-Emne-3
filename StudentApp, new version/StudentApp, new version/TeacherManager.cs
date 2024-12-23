namespace StudentApp__new_version
{
    internal class TeacherManager
    {
        private string line = new('_', 60);
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

            Console.WriteLine("\nSelect a student to enlist");
            int inputId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (inputId == null)
            {
                Console.WriteLine("Invalid Id");
            }
            var chosenStudent = users.Find(u => u.Id == inputId);
            Console.WriteLine($"Student {chosenStudent.Name}'s available classes\n");
            Console.WriteLine("Select a subject");
            Console.WriteLine($"{line}");
            foreach (var s in subjectList)
            {
                Console.WriteLine($"{s.SchoolSubjectId}.{s.SubjectName}");
            }

            Console.WriteLine($"{line}");
            int inputId2 = Convert.ToInt32(Console.ReadLine());
            if (inputId2 == null)
            {
                Console.WriteLine("Invalid Id");
            }
            var chosenSubject = subjectList.Find(s => s.SchoolSubjectId == inputId2);
            Console.Clear();
            Console.WriteLine($"\n{chosenStudent.Name} is now in the {chosenSubject.SubjectName} class\n");

            if (chosenStudent is Student checkStudent)
            {
                checkStudent.GetOngoingList().Add(chosenSubject);
            }
        }


    }
}
