using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class AddTeamToUserApplicationServiceTest : IntegrationTestBase
    {
        private AddTeamToUserApplicationService _addTeamToUserApplicationService;
        private UserPersist _userPersist;
        private TeamPersist _teamPersist;
        private UserRepository _userRepositoty;

        [SetUp]
        public void SetUp()
        {
            _addTeamToUserApplicationService = GetInstance<AddTeamToUserApplicationService>();
            _userRepositoty = GetInstance<UserRepository>();
            _userPersist = GetInstance<UserPersist>();
            _teamPersist = GetInstance<TeamPersist>();
        }

        [Test]
        public void Should_add_a_team_to_the_user()
        {
            var user = UserBuilder.New().Build();
            _userPersist.Add(user);
            var teamExpected = TeamBuilder.New().Build();
            _teamPersist.Add(teamExpected);
            var addTeamToUserDto = new AddTeamToUserDto() { UserId = user.Id, TeamId = teamExpected.Id};

            _addTeamToUserApplicationService.Add(addTeamToUserDto);
            user = _userRepositoty.Get(user.Id);
            
            Assert.AreEqual(new[] {teamExpected}, user.Teams);
        }
    }
}
