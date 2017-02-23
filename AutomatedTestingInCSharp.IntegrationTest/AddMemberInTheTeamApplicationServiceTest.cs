using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using FluentNHibernate.Conventions;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class AddMemberInTheTeamApplicationServiceTest : IntegrationTestBase
    {
        private AddMemberInTheTeamApplicationService _addMemberInTheTeam;
        private MemberPersist _memberPersist;
        private TeamPersist _teamPersist;
        private TeamRepository _teamRepository;

        [SetUp]
        public void Init()
        {
            _addMemberInTheTeam = GetInstance<AddMemberInTheTeamApplicationService>();
            _memberPersist = GetInstance<MemberPersist>();
            _teamPersist = GetInstance<TeamPersist>();
            _teamRepository = GetInstance<TeamRepository>();
        }

        [Test]
        public void Should_add_a_member_in_team_and_persist_in_the_repository()
        {
            var teamExpected = TeamBuilder.New().Build();
            _teamPersist.Add(teamExpected);
            var newDeveloper = MemberBuilder.New().With(m => m.Role, Role.Developer).Build();
            _memberPersist.Add(newDeveloper);
            var addMemberInTheTeamDto = new AddMemberInTheTeamDto() { TeamId = teamExpected.Id, MemberId = newDeveloper.Id };

            _addMemberInTheTeam.Add(addMemberInTheTeamDto);

            var team = _teamRepository.Get(addMemberInTheTeamDto.TeamId);
            Assert.AreEqual(teamExpected.Id, team.Id);
            Assert.IsTrue(team.Members.Any(m => m.Id == newDeveloper.Id));
        }
    }
}
