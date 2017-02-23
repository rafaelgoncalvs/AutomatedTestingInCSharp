namespace AutomatedTestingInCSharp.Domain
{
    public class Client : Entity<Client>
    {
        public virtual string Name { get; protected set; }

        protected Client() { }

        public Client(string name)
        {
            Name = name;
        }
    }
}