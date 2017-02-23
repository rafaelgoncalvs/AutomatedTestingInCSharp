using System.Collections.Generic;
using System.Linq;
using AutomatedTestingInCSharp.Domain;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.UnitTest
{
    [TestFixture]
    public class TeamTest
    {
        private Project[] _projects = {ProjectBuilder.New().Build()};

        private readonly Member[] _members =
        {
            MemberBuilder.New().With(m => m.Role, Role.ScrumMaster).Build(),
            MemberBuilder.New().With(m => m.Role, Role.ProductOwner).Build(),
            MemberBuilder.New().With(m => m.Role, Role.Developer).Build(),
        };

        private const string ProjectName = "Rafael";

        [Test]
        public void Should_create_an_team_with_at_least_one_scrum_master_and_one_product_owner_and_one_developer_and_one_project()
        {
            var team = TeamBuilder.New().With(t => t.Name, ProjectName).WithCollection(t => t.Members, _members)
                .WithCollection(t => t.Projects, _projects).Build();

            Assert.AreEqual(ProjectName, team.Name);
            Assert.AreEqual(_members, team.Members);
            Assert.AreEqual(_projects, team.Projects);
        }

        [Test]
        public void Should_not_create_an_team_without_at_least_one_scrum_master()
        {
            var members = new[]
            {
                MemberBuilder.New().With(m => m.Role, Role.ProductOwner).Build(),
                MemberBuilder.New().With(m => m.Role, Role.Developer).Build(),
            };

            TestDelegate testDelegate = () => new Team(ProjectName, members, _projects);

            Assert.Throws<DomainException>(testDelegate);
        }

        [Test]
        public void Should_not_create_an_team_without_at_least_one_product_owner()
        {
            var members = new[]
            {
                MemberBuilder.New().With(m => m.Role, Role.ScrumMaster).Build(),
                MemberBuilder.New().With(m => m.Role, Role.Developer).Build(),
            };

            TestDelegate testDelegate = () => new Team(ProjectName, members, _projects);

            Assert.Throws<DomainException>(testDelegate);
        }

        [Test]
        public void Should_not_create_an_team_without_at_least_one_developer()
        {
            _projects = new[] {ProjectBuilder.New().Build()};
            var members = new[]
            {
                MemberBuilder.New().With(m => m.Role, Role.ScrumMaster).Build(),
                MemberBuilder.New().With(m => m.Role, Role.ProductOwner).Build(),
            };

            TestDelegate testDelegate = () => new Team(ProjectName, members, _projects);

            Assert.Throws<DomainException>(testDelegate);
        }

        [Test]
        public void Should_not_create_an_team_without_at_least_one_project()
        {
            _projects = new Project[] {};

            TestDelegate testDelegate = () => new Team(ProjectName, _members, _projects);

            Assert.Throws<DomainException>(testDelegate);
        }

        [Test]
        public void Should_add_a_member_in_the_team()
        {
            var memberExpected = MemberBuilder.New().Build();
            var team = TeamBuilder.New().Build();

            team.AddMember(memberExpected);

            Assert.IsTrue(team.Members.Any(m => memberExpected == m));
        }

        [Test]
        public void Should_add_a_member_in_the_team_()
        {
            //Arrange
            var memberExpected = new Member("Member name", "member@test.com.br", Role.Developer);
            var developer = new Member("Developer name", "developer@test.com.br", Role.Developer);
            var scrumMaster = new Member("ScrumMaster name", "developer@test.com.br", Role.ScrumMaster);
            var productOwner = new Member("ProductOwner name", "developer@test.com.br", Role.ProductOwner);
            IList<Member> members = new List<Member> { developer, scrumMaster, productOwner };
            var client = new Client("Client name");
            var project = new Project("Project name", client);
            IList<Project> projects = new List<Project> { project };
            var team = new Team("Team name", members, projects);

            //Action
            team.AddMember(memberExpected);

            //Assert
            Assert.IsTrue(team.Members.Any(m => memberExpected == m));
        }
    }
}
