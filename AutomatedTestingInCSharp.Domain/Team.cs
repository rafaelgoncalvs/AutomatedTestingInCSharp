using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTestingInCSharp.Domain
{
    public class Team : Entity<Team>
    {
        public virtual string Name { get; protected set; }
        private readonly IList<Member> _members = new List<Member>();
        public virtual IEnumerable<Member> Members => _members;
        private readonly IList<Project> _projects = new List<Project>();
        public virtual IEnumerable<Project> Projects => _projects;

        protected Team() { }

        public Team(string name, IList<Member> members, IList<Project> projects)
        {
            ValidateTeamMembers(members);
            ValidateProjects(projects);
            Name = name;
            _members = members;
            _projects = projects;
        }

        private static void ValidateProjects(ICollection<Project> projects)
        {
            if (IsNotThereAProject(projects))
            {
                throw new DomainException();
            }
        }

        private static bool IsNotThereAProject(ICollection<Project> projects)
        {
            return projects.Count == 0;
        }

        private static void ValidateTeamMembers(IEnumerable<Member> members)
        {
            if (IsNotThereAScrumMaster(members) || IsNotThereAProductOwner(members) || IsNotThereADeveloper(members))
            {
                throw new DomainException();
            }
        }
        
        private static bool IsNotThereAScrumMaster(IEnumerable<Member> members)
        {
            return IsNotThereARoleMember(members, Role.ScrumMaster);
        }

        private static bool IsNotThereAProductOwner(IEnumerable<Member> members)
        {
            return IsNotThereARoleMember(members, Role.ProductOwner);
        }

        private static bool IsNotThereADeveloper(IEnumerable<Member> members)
        {
            return IsNotThereARoleMember(members, Role.Developer);
        }

        private static bool IsNotThereARoleMember(IEnumerable<Member> members, Role role)
        {
            return members.All(member => role != member.Role);
        }

        public virtual void AddMember(Member member)
        {
            _members.Add(member);
        }
    }
}