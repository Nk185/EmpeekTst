using System.Web.Http;

namespace EmpeekTst
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{drive}",
                defaults: new { drive = RouteParameter.Optional }
            );
        }
    }
}