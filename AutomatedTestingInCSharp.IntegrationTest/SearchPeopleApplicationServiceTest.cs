using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class SearchPeopleApplicationServiceTest : IntegrationTestBase
    {
        private SearchPeopleApplicationService _searchPeopleApplicationService;
        private PeopleRepository _peopleRepository;

        [SetUp]
        public void SetUp()
        {
            _searchPeopleApplicationService = GetInstance<SearchPeopleApplicationService>();
            _peopleRepository = GetInstance<PeopleRepository>();
        }

        [Test]
        public void Should_search_people()
        {
            var person1 = PersonBuilder.New().WithName("Person 1").Build();
            var person2 = PersonBuilder.New().WithEmail("person@teste.com").Build();
            _peopleRepository.Add(person1);
            _peopleRepository.Add(person2);

            var peopleDto = _searchPeopleApplicationService.Search();

            Assert.IsTrue(peopleDto.Any(person => person1.Email == person.Email && person1.Name == person.Name));
            Assert.IsTrue(peopleDto.Any(person => person2.Email == person.Email && person2.Name == person.Name));
        }
    }
}
