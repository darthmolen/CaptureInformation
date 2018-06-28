using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using CaptureInformation.Handlers;

namespace CaptureInformation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /// INFO: Message Handlers are additions to the pipeline and are used to grab stuff before they get handed off to MVC
            config.MessageHandlers.Add(new LogRequestWebApiHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
