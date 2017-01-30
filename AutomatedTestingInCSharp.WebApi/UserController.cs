using System.Web.Http;
using AutomatedTestingInCSharp.Application;

namespace AutomatedTestingInCSharp.WebApi
{
    [RoutePrefix("people")]
    public class UserController : ApiController
    {
        private readonly AddUserApplicationService _addUserApplicationService;

        private readonly SearchUserApplicationService _searchUserApplicationService;

        public UserController(AddUserApplicationService addUserApplicationService, SearchUserApplicationService searchUserApplicationService)
        {
            _addUserApplicationService = addUserApplicationService;
            _searchUserApplicationService = searchUserApplicationService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var peopleDto = _searchUserApplicationService.Search();
            return Ok(peopleDto);
        }
        
        [HttpPost, Route("")]
        public IHttpActionResult Post(AddUserHttpDto addUserHttpDto)
        {
            var addUserDto = MapAddUserDto(addUserHttpDto);
            var userId = _addUserApplicationService.Add(addUserDto);
            return Ok(userId);
        }

        private static AddUserDto MapAddUserDto(AddUserHttpDto addUserHttpDto)
        {
            return new AddUserDto()
            {
                Name = addUserHttpDto.Name,
                Email = addUserHttpDto.Email
            };
        }
    }
}