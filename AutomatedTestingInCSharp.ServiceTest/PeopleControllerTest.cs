using System;
using System.Collections.Generic;
using System.Net;
using AutomatedTestingInCSharp.Application;
using NUnit.Framework;
using SimpleInjector;

namespace AutomatedTestingInCSharp.ServiceTest
{
    [TestFixture]
    public class PeopleControllerTest : ServiceTestBase
    {
        private AddPersonApplicationService _addPersonApplicationService;

        public override void RegisterApplicationService(Container dependencyInjectionContainer)
        {
            dependencyInjectionContainer.Register(() => new AddPersonApplicationService(null));
            _addPersonApplicationService = dependencyInjectionContainer.GetInstance<AddPersonApplicationService>();
        }

        [Test]
        public void Should_get_people()
        {
            var response = HttpClient.GetAsync("http://localhost:1984/people").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
