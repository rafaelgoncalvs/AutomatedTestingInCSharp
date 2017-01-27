using System.Collections.Generic;
using System.Net;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.WebApi;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.ServiceTest
{
    [TestFixture]
    public class PeopleControllerTest : ServiceTestBase
    {
        private AddPersonApplicationService _addPersonApplicationService;

        public override IEnumerable<object> GetControllersForRegistering()
        {
            
            _addPersonApplicationService = new AddPersonApplicationService(null);
            return new[] { new PeopleController(_addPersonApplicationService) };
        }

        [Test]
        public void Should_get_people()
        {
            var response = HttpClient.GetAsync($"{AdressBase}/people").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
