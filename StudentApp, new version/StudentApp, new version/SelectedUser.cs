namespace StudentApp__new_version
{
    internal class SelectedUser
    {
        public IUser LoggedInStudent { get; private set; }

        public SelectedUser()
        {

        }

        public IUser GetLoggedIn()
        {
            return LoggedInStudent;
        }

        public IUser SetLoggedInStudent(IUser foundUser)
        {
            return LoggedInStudent = foundUser;
        }
    }
}
