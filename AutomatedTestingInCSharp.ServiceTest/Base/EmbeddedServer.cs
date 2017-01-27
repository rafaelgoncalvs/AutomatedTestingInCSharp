using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Testing;
using Owin;

namespace AutomatedTestingInCSharp.ServiceTest.Base
{
    public class EmbeddedServer
    {
        private readonly IEnumerable<object> _controllers;
        private readonly string _adressBase;

        public TestServer Server { get; private set; }

        public EmbeddedServer(IEnumerable<object> controllers, string adressBase = "http://localhost:1984")
        {
            _controllers = controllers;
            _adressBase = adressBase;
        }

        public void Start()
        {
            Action<IAppBuilder> actionForCreatingAppBuilder = app =>
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Services.Replace(typeof(IHttpControllerActivator), new SimpleInjectorControllerActivator(_controllers));
                
                /* TODO: Outra opcao de configuracao
                 * using Autofac;
                 * using Autofac.Integration.WebApi;
                var containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterApiControllers(Assembly.GetAssembly(typeof (PeopleController)));
                containerBuilder.RegisterWebApiFilterProvider(config);
                var container = containerBuilder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                app.UseAutofacMiddleware(container);
                app.UseAutofacWebApi(config);
                */

                app.UseWebApi(config);
            };

            Server = TestServer.Create(actionForCreatingAppBuilder);
            Server.BaseAddress = new Uri(_adressBase);
        }

        public void Stop()
        {
            Server.Dispose();
        }
    }
}
