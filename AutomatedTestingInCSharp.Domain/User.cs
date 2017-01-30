using System.Collections.Generic;

namespace AutomatedTestingInCSharp.Domain
{
    public class User : Entity<User>
    {
        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }
        private readonly IList<Team> _teams = new List<Team>();
        public virtual IEnumerable<Team> Teams => _teams;

        protected User() { }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public virtual void AddTeam(Team team)
        {
            _teams.Add(team);
        }
    }
}
