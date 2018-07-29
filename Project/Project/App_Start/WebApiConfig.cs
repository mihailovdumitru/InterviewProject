using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Setting security protocol for all HTTP calls
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                                        SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

            //Setting and enabling Cors attributes for all HTTP calls
            var enableCorsAttribute = new EnableCorsAttribute("*",
                                   "Origin, Content-Type, Accept",
                                   "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);
        }
    }
}
