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

        public void Add(AddPersonDto addPersonDto)
        {
            var pessoa = new Person(addPersonDto.Name, addPersonDto.Email);
            _peopleRepository.Add(pessoa);
        }
    }
}
