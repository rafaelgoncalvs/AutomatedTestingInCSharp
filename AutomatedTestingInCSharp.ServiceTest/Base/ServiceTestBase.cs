using System.Collections.Generic;
using System.Net.Http;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.ServiceTest.Base
{
    [TestFixture]
    public abstract class ServiceTestBase
    {
        private EmbeddedServer _embeddedServer;
        protected HttpClient HttpClient;
        protected string AdressBase = "http://localhost:1984";

        [SetUp]
        public void SetUp()
        {
            var controllers = GetControllersForRegistering();
            
            _embeddedServer = new EmbeddedServer(controllers, AdressBase);
            _embeddedServer.Start();

            HttpClient = _embeddedServer.Server.HttpClient;
        }

        public abstract IEnumerable<object> GetControllersForRegistering();
        
        [TearDown]
        public void TearDown()
        {
            _embeddedServer.Stop();
        }
    }
}