namespace AutomatedTestingInCSharp.Domain
{
    public class User : Entity<User>
    {
        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }

        protected User() { }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
