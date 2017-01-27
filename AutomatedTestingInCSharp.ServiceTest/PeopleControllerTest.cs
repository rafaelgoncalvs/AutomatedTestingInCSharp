using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.WebApi;
using Moq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.ServiceTest
{
    [TestFixture]
    public class PeopleControllerTest : ServiceTestBase
    {
        private AddPersonApplicationService _addPersonApplicationService;

        private SearchPeopleApplicationService _searchPeopleApplicationService;

        public override IEnumerable<object> GetControllersForRegistering()
        {
            var peopleRepository = Substitute.For<PeopleRepository>();
            _addPersonApplicationService = Substitute.For<AddPersonApplicationService>(peopleRepository);
            _searchPeopleApplicationService = Substitute.For<SearchPeopleApplicationService>(peopleRepository);
            return new[] { new PeopleController(_addPersonApplicationService, _searchPeopleApplicationService) };
        }

        [Test]
        public void Should_get_people()
        {
            var personDto1 = new PersonDto() {Name = "Person 1", Email = "person1@teste.com", Id = 32};
            var personDto2 = new PersonDto() { Name = "Person 2", Email = "person2@teste.com", Id = 485};
            _searchPeopleApplicationService.Search().Returns(new [] { personDto1, personDto2 });

            var response = HttpClient.GetAsync($"{AdressBase}/people").Result;
            var people = response.Content.ReadAsAsync<IEnumerable<PersonDto>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(people.Any(person => personDto1.Email == person.Email && personDto1.Name == person.Name && personDto1.Id == person.Id));
            Assert.IsTrue(people.Any(person => personDto2.Email == person.Email && personDto2.Name == person.Name && personDto2.Id == person.Id));
        }

        [Test]
        public void Should_add_person()
        {
            var addPersonHttpDto = new AddPersonHttpDto() { Email = "rafael@teste.com", Name = "Rafael Gonçalves"};
            AddPersonDto addPersonDto = null;
            _addPersonApplicationService.When(function => function.Add(Arg.Any<AddPersonDto>())).Do(param => addPersonDto = param.ArgAt<AddPersonDto>(0));
            var httpContent = new StringContent(JsonConvert.SerializeObject(addPersonHttpDto), Encoding.UTF8, "application/json");

            var response = HttpClient.PostAsync($"{AdressBase}/people", httpContent).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(addPersonHttpDto.Name, addPersonDto.Name);
            Assert.AreEqual(addPersonHttpDto.Email, addPersonDto.Email);
        }
    }
}
