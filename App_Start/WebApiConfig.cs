using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PropertyService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
            );

            //config.Routes.MapHttpRoute(
            //    name: "CheckConnection",
            //    routeTemplate: "api/{controller}",
            //    defaults: new { controller = "CheckConnection" }
            //    );

            config.Routes.MapHttpRoute(
                name: "ApiVer1",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "checkConnection", action = "GetAllConnection" }
                );
                

        }
    }
}
