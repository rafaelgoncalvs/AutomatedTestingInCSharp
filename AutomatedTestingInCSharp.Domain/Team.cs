namespace AutomatedTestingInCSharp.Domain
{
    public class Team : Entity<Team>
    {
        public virtual string Name { get; protected set; }

        protected Team() { }

        public Team(string name)
        {
            Name = name;
        }
    }
}