using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using NHibernate.Util;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class AddMemberInTheTeamApplicationServiceWithoutPersistTest : IntegrationTestBase
    {
        private AddMemberInTheTeamApplicationService _addMemberInTheTeam;
        private TeamRepository _teamRepository;
        private MemberRepository _memberRepository;
        private ProjectRepository _projectRepository;
        private ClientRepository _clientRepository;

        [SetUp]
        public void Init()
        {
            _addMemberInTheTeam = GetInstance<AddMemberInTheTeamApplicationService>();
            _teamRepository = GetInstance<TeamRepository>();
            _memberRepository = GetInstance<MemberRepository>();
            _projectRepository = GetInstance<ProjectRepository>();
            _clientRepository = GetInstance<ClientRepository>();
        }

        [Test]
        public void Should_add_a_member_in_team_and_persist_in_the_repository()
        {
            //Arrange
            var teamExpected = TeamBuilder.New().Build();
            teamExpected.Projects.ForEach(project =>
            {
                _clientRepository.Add(project.Client);
                _projectRepository.Add(project);
            });
            teamExpected.Members.ForEach(member => _memberRepository.Add(member));
            _teamRepository.Add(teamExpected);
            var newDeveloper = MemberBuilder.New().With(m => m.Role, Role.Developer).Build();
            _memberRepository.Add(newDeveloper);
            var addMemberInTheTeamDto = new AddMemberInTheTeamDto() { TeamId = teamExpected.Id, MemberId = newDeveloper.Id };

            //Action
            _addMemberInTheTeam.Add(addMemberInTheTeamDto);

            //Assert
            var team = _teamRepository.Get(addMemberInTheTeamDto.TeamId);
            Assert.AreEqual(teamExpected.Id, team.Id);
            Assert.IsTrue(team.Members.Any(m => m.Id == newDeveloper.Id));
        }
    }
}
