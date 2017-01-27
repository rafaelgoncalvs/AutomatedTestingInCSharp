using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class AddPersonApplicationService
    {
        private readonly PeopleRepository _peopleRepository;
        
        public AddPersonApplicationService(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public virtual int Add(AddPersonDto addPersonDto)
        {
            var person = new Person(addPersonDto.Name, addPersonDto.Email);
            _peopleRepository.Add(person);
            return person.Id;
        }
    }
}
