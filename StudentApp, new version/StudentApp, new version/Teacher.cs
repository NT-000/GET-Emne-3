using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class Teacher
    {
        public static int IdTeacherCounter = 1;
        public int TeacherId { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }

        public string Password { get; private set; }

        public List<Teacher> TeacherList { get; private set;} 

        public Teacher(string name, string password)
        {
            TeacherId = IdTeacherCounter++;
            Name = name;
            Password = password;
            Type = "Teacher";
        }

        public Teacher()
        {
            TeacherList = new List<Teacher>();
        }

        public void InitializingTeacher()
        {
            TeacherList =
            [
                new Teacher("Arne", "123"),
            ];
        }

        public List<Teacher> GetTeacherList()
        {
            return TeacherList;
        }
    }
}
