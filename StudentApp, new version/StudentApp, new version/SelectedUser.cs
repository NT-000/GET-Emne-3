using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp__new_version
{
    internal class SelectedUser
    {
        public Student LoggedInStudent { get; private set; }

        public SelectedUser()
        {

        }

        public Student GetLoggedIn()
        {
            return LoggedInStudent;
        }

        public Student SetLoggedInStudent(Student foundUser)
        {
          return  LoggedInStudent = foundUser;
        }
    }
}
