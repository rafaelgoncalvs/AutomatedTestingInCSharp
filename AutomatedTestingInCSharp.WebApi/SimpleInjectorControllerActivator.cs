using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace AutomatedTestingInCSharp.WebApi
{
    public class SimpleInjectorControllerActivator : IHttpControllerActivator
    {
        private readonly IEnumerable<object> _controllers;

        public SimpleInjectorControllerActivator(IEnumerable<object> controllers)
        {
            _controllers = controllers;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var httpController = (IHttpController)_controllers.SingleOrDefault(controller => controllerType == controller.GetType());
            if (httpController == null)
            {
                throw new ArgumentException("None controller registered for request: " + request.RequestUri);
            }
            return httpController;
        }
    }
}