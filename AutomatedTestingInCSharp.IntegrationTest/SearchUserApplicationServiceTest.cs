using System;
using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class SearchUserApplicationServiceTest : IntegrationTestBase
    {
        private SearchUserApplicationService _searchUserApplicationService;
        private UserPersist _userPersist;

        [SetUp]
        public void SetUp()
        {
            _searchUserApplicationService = GetInstance<SearchUserApplicationService>();
            _userPersist = GetInstance<UserPersist>();
        }

        [Test]
        public void Should_search_users()
        {
            var user1 = UserBuilder.New().With(u => u.Name, "User 1").Build();
            var user2 = UserBuilder.New().With(u => u.Email, "person@teste.com").Build();
            _userPersist.Add(user1);
            _userPersist.Add(user2);

            var userDtos = _searchUserApplicationService.Search();

            Assert.AreEqual(2, userDtos.Count());
            Assert.IsTrue(userDtos.Any(user => IsEqual(user1, user)));
            Assert.IsTrue(userDtos.Any(user => IsEqual(user2, user)));
        }
        
        [Test]
        public void Should_search_users_with_teams()
        {
            var user = UserBuilder.New().Build();
            var teamA = TeamBuilder.New().Build();
            var teamB = TeamBuilder.New().Build();
            user.AddTeam(teamA);
            user.AddTeam(teamB);
            _userPersist.Add(user);

            var userDtos = _searchUserApplicationService.Search();
            var teamDtos = userDtos.First().Teams;

            Assert.AreEqual(2, teamDtos.Count());
            Assert.IsTrue(teamDtos.Any(team => IsEqual(teamA, team)));
            Assert.IsTrue(teamDtos.Any(team => IsEqual(teamB, team)));
        }
        
        private static bool IsEqual(User user, UserDto userDto)
        {
            return user.Id == userDto.Id && user.Email == userDto.Email && user.Name == userDto.Name;
        }

        private static bool IsEqual(Team team, TeamDto teamDto)
        {
            return team.Id == teamDto.Id && team.Name == teamDto.Name;
        }
    }
}
