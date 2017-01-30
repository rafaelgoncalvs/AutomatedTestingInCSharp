using System.Collections.Generic;

namespace AutomatedTestingInCSharp.Application
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<TeamDto> Teams { get; set; }
    }
}