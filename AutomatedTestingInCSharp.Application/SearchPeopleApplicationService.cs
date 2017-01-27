using System.Collections.Generic;
using System.Linq;
using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class SearchPeopleApplicationService
    {
        private readonly PeopleRepository _peopleRepository;
        
        public SearchPeopleApplicationService(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public virtual IEnumerable<PersonDto> Search()
        {
            var people = _peopleRepository.GetAll();
            return people.Select(MapPersonDto);
        }

        private static PersonDto MapPersonDto(Person person)
        {
            return new PersonDto()
            {
                Email = person.Email,
                Name = person.Name,
                Id = person.Id
            };
        }
    }
}