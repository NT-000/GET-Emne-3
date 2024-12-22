namespace StudentApp__new_version
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; private set; }

        public string GetType()
        {
            return Type;
        }
    }

}
