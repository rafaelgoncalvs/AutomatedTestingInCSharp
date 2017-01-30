using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class AddUserApplicationService
    {
        private readonly UserRepository _userRepository;
        
        public AddUserApplicationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public virtual int Add(AddUserDto addUserDto)
        {
            var person = new User(addUserDto.Name, addUserDto.Email);
            _userRepository.Add(person);
            return person.Id;
        }
    }
}
