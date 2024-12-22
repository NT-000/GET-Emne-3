namespace StudentApp__new_version
{
    public interface IUser
    {
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string Password { get; }
    }
}
