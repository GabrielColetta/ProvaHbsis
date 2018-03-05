using System.Net.Http.Headers;
using System.Web.Http;
using Library.IoC;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(Library.Api.Startup))]

namespace Library.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration
            {
                DependencyResolver =
                    new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices())
            };

            Register(config);
            app.UseCors(CorsOptions.AllowAll);
            
            app.UseWebApi(config);
        }

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/id",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}