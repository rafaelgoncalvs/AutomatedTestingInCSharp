using System.Web.Http;
using AutomatedTestingInCSharp.Application;

namespace AutomatedTestingInCSharp.WebApi
{
    [RoutePrefix("people")]
    public class PeopleController : ApiController
    {
        private readonly AddPersonApplicationService _addPersonApplicationService;

        public PeopleController(AddPersonApplicationService addPersonApplicationService)
        {
            _addPersonApplicationService = addPersonApplicationService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var peopleDto = new[] { new PersonDto() { Id = 1, Name = "Tefsdf", Email = "dfsdfsd"} };
            return Ok(peopleDto);
        }
    }

    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}