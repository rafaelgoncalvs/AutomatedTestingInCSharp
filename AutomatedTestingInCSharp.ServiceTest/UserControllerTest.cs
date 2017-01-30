using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.ServiceTest.Base;
using AutomatedTestingInCSharp.WebApi;
using Moq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.ServiceTest
{
    [TestFixture]
    public class UserControllerTest : ServiceTestBase
    {
        private AddUserApplicationService _addUserApplicationService;

        private SearchUserApplicationService _searchUserApplicationService;

        public override IEnumerable<object> GetControllersForRegistering()
        {
            var peopleRepository = Substitute.For<UserRepository>();
            _addUserApplicationService = Substitute.For<AddUserApplicationService>(peopleRepository);
            _searchUserApplicationService = Substitute.For<SearchUserApplicationService>(peopleRepository);
            return new[] { new UserController(_addUserApplicationService, _searchUserApplicationService) };
        }

        [Test]
        public void Should_get_an_users()
        {
            var personDto1 = new UserDto() {Name = "User 1", Email = "person1@teste.com", Id = 32};
            var personDto2 = new UserDto() { Name = "User 2", Email = "person2@teste.com", Id = 485};
            _searchUserApplicationService.Search().Returns(new [] { personDto1, personDto2 });

            var response = HttpClient.GetAsync($"{AdressBase}/people").Result;
            var people = response.Content.ReadAsAsync<IEnumerable<UserDto>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(people.Any(person => personDto1.Email == person.Email && personDto1.Name == person.Name && personDto1.Id == person.Id));
            Assert.IsTrue(people.Any(person => personDto2.Email == person.Email && personDto2.Name == person.Name && personDto2.Id == person.Id));
        }

        [Test]
        public void Should_add_an_user()
        {
            var addUserHttpDto = new AddUserHttpDto() { Email = "rafael@teste.com", Name = "Rafael Gonçalves"};
            AddUserDto addUserDto = null;
            _addUserApplicationService.When(function => function.Add(Arg.Any<AddUserDto>())).Do(param => addUserDto = param.ArgAt<AddUserDto>(0));
            var httpContent = new StringContent(JsonConvert.SerializeObject(addUserHttpDto), Encoding.UTF8, "application/json");

            var response = HttpClient.PostAsync($"{AdressBase}/people", httpContent).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(addUserHttpDto.Name, addUserDto.Name);
            Assert.AreEqual(addUserHttpDto.Email, addUserDto.Email);
        }
    }
}
