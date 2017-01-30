using System.Collections.Generic;
using System.Linq;
using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class SearchUserApplicationService
    {
        private readonly UserRepository _userRepository;
        
        public SearchUserApplicationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual IEnumerable<UserDto> Search()
        {
            var users = _userRepository.GetAll();
            return users.Select(MapUserDto);
        }

        private static UserDto MapUserDto(User user)
        {
            return new UserDto()
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id
            };
        }
    }
}