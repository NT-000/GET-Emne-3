namespace StudentApp__new_version
{
    internal class Teacher : IUser
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Password { get; private set; }

        public Teacher(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            Type = "Teacher";
        }

        public Teacher()
        {
        }

    }
}
