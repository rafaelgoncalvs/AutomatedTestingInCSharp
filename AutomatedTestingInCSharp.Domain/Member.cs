namespace AutomatedTestingInCSharp.Domain
{
    public class Member : Entity<Member>
    {
        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual Role Role { get; protected set; }

        protected Member() { }

        public Member(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
        }
        
    }
}
