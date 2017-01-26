using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using SimpleInjector;

namespace AutomatedTestingInCSharp.WebApi
{
    public class SimpleInjectorControllerActivator : IHttpControllerActivator
    {
        private readonly Container _container;

        public SimpleInjectorControllerActivator(Container container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return (IHttpController)_container.GetInstance(controllerType);
        }
    }
}