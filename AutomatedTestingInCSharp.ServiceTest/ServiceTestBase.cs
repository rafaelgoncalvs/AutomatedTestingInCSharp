using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using NUnit.Framework;
using SimpleInjector;

namespace AutomatedTestingInCSharp.ServiceTest
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
            var dependencyInjectionContainer = new Container();
            RegisterApplicationService(dependencyInjectionContainer);
            
            _embeddedServer = new EmbeddedServer(dependencyInjectionContainer, AdressBase);
            _embeddedServer.Start();

            HttpClient = _embeddedServer.Server.HttpClient;
        }

        public abstract void RegisterApplicationService(Container dependencyInjectionContainer);
        
        [TearDown]
        public void TearDown()
        {
            _embeddedServer.Stop();
        }
    }
}