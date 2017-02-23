using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.ServiceTest.Base;
using AutomatedTestingInCSharp.WebApi;
using Moq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.ServiceTest
{
    [TestFixture]
    public class TeamControllerTest : ServiceTestBase
    {
        private AddMemberInTheTeamApplicationService _addMemberInTheTeam;
        
        public override IEnumerable<object> GetControllersForRegistering()
        {
            var teamRepository = Substitute.For<TeamRepository>();
            var memberRepository = Substitute.For<MemberRepository>();
            _addMemberInTheTeam = Substitute.For<AddMemberInTheTeamApplicationService>(teamRepository, memberRepository);
            return new[] { new TeamController(_addMemberInTheTeam) };
        }
        
        [Test]
        public void Should_add_an_user()
        {
            const int teamId = 654;
            const int memberId = 6812;
            var addMemberInTheTeamHttpDto = new AddMemberInTheTeamHttpDto() { TeamId = teamId, MemberId = memberId };
            AddMemberInTheTeamDto addMemberInTheTeamDto = null;
            _addMemberInTheTeam.When(function => function.Add(Arg.Any<AddMemberInTheTeamDto>())).Do(param => addMemberInTheTeamDto = param.ArgAt<AddMemberInTheTeamDto>(0));
            var httpContent = new StringContent(JsonConvert.SerializeObject(addMemberInTheTeamHttpDto), Encoding.UTF8, "application/json");

            var response = HttpClient.PostAsync($"{AdressBase}/teams", httpContent).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(addMemberInTheTeamHttpDto.TeamId, addMemberInTheTeamDto.TeamId);
            Assert.AreEqual(addMemberInTheTeamHttpDto.MemberId, addMemberInTheTeamDto.MemberId);
        }
    }
}
