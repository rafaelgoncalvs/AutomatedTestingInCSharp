namespace AutomatedTestingInCSharp.Domain
{
    public class Project : Entity<Project>
    {
        public virtual string Name { get; protected set; }
        public virtual Client Client { get; protected set; }

        protected Project() { }

        public Project(string name, Client client)
        {
            Name = name;
            Client = client;
        }
    }
}