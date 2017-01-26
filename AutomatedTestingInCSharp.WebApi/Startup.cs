using System.Web.Http;
using System.Web.Http.Dispatcher;
using AutomatedTestingInCSharp.Application;
using NSubstitute;
using Owin;
using SimpleInjector;

namespace AutomatedTestingInCSharp.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            
            app.UseWebApi(httpConfiguration);
        }
    }
}
