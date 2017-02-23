using System.Web.Http;
using AutomatedTestingInCSharp.Application;

namespace AutomatedTestingInCSharp.WebApi
{
    [RoutePrefix("teams")]
    public class TeamController : ApiController
    {
        private readonly AddMemberInTheTeamApplicationService _addMemberInTheTeam;

        public TeamController(AddMemberInTheTeamApplicationService addMemberInTheTeamApplicationService)
        {
            _addMemberInTheTeam = addMemberInTheTeamApplicationService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok();
        }
        
        [HttpPost, Route("")]
        public IHttpActionResult Post(AddMemberInTheTeamHttpDto addMemberInTheTeamHttpDto)
        {
            var addMemberInTheTeamDto = new AddMemberInTheTeamDto()
            {
                TeamId = addMemberInTheTeamHttpDto.TeamId, MemberId = addMemberInTheTeamHttpDto.MemberId
            };
            _addMemberInTheTeam.Add(addMemberInTheTeamDto);
            return Ok();
        }
    }
}