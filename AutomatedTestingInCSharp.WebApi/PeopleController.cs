using System.Web.Http;
using AutomatedTestingInCSharp.Application;

namespace AutomatedTestingInCSharp.WebApi
{
    [RoutePrefix("people")]
    public class PeopleController : ApiController
    {
        private readonly AddPersonApplicationService _addPersonApplicationService;

        private readonly SearchPeopleApplicationService _searchPeopleApplicationService;

        public PeopleController(AddPersonApplicationService addPersonApplicationService, SearchPeopleApplicationService searchPeopleApplicationService)
        {
            _addPersonApplicationService = addPersonApplicationService;
            _searchPeopleApplicationService = searchPeopleApplicationService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var peopleDto = _searchPeopleApplicationService.Search();
            return Ok(peopleDto);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(AddPersonHttpDto addPersonHttpDto)
        {
            var addPersonDto = MapAddPersonDto(addPersonHttpDto);
            var personId = _addPersonApplicationService.Add(addPersonDto);
            return Ok(personId);
        }

        private static AddPersonDto MapAddPersonDto(AddPersonHttpDto addPersonHttpDto)
        {
            return new AddPersonDto()
            {
                Name = addPersonHttpDto.Name,
                Email = addPersonHttpDto.Email
            };
        }
    }
}