using System.Linq;
using AutomatedTestingInCSharp.Domain;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.UnitTest
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void Should_create_an_user()
        {
            const string name = "Rafael";
            const string email = "rafael@test.com";

            var user = UserBuilder.New().With(u => u.Name, name).With(u => u.Email, email).Build();

            Assert.AreEqual(name, user.Name);
            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void Should_add_a_team_to_the_user()
        {
            var user = UserBuilder.New().Build();
            var team = TeamBuilder.New().Build();

            user.AddTeam(team);

            Assert.AreEqual(1, user.Teams.Count());
            Assert.True(user.Teams.Any(t => team == t));
            // OR
            //Assert.AreEqual(new[] {team}, user.Teams);
        }
    }
}
