using LaGuineuApi.Handlers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

namespace LaGuineuApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            // List of delegating handlers.
            DelegatingHandler[] handlers = new DelegatingHandler[] {
             new AuthorizationHandler()
            };

            // Create a message handler chain with an end-point.
            var routeHandlers = HttpClientFactory.CreatePipeline(
                new HttpControllerDispatcher(config), handlers);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints:null,
                handler: routeHandlers
            );

        }
    }
}
