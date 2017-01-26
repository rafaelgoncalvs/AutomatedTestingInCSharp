using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using AutomatedTestingInCSharp.WebApi;
using Microsoft.Owin.Testing;
using Owin;
using SimpleInjector;

namespace AutomatedTestingInCSharp.ServiceTest
{
    public class EmbeddedServer
    {
        private readonly Container _dependencyInjectionContainer;
        private readonly string _adressBase;

        public TestServer Server { get; private set; }

        public EmbeddedServer(Container dependencyInjectionContainer, string adressBase = "http://localhost:1984")
        {
            _dependencyInjectionContainer = dependencyInjectionContainer;
            _adressBase = adressBase;
        }

        public void Start()
        {
            Action<IAppBuilder> actionForCreatingAppBuilder = app =>
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Services.Replace(typeof(IHttpControllerActivator), new SimpleInjectorControllerActivator(_dependencyInjectionContainer));
                
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
