using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.WebHost;
using System.Web.Mvc;

namespace PropertyService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //customize your route
            //var config = GlobalConfiguration.Configuration;
            //config.Services.Replace(typeof(IHttpControllerSelector), new MyControllerSelector(config));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
            );

            config.Routes.MapHttpRoute(
                name: "CheckConnection",
                routeTemplate: "api/{controller}",
                defaults: new { controller = "CheckConnection" }
                );

            config.Routes.MapHttpRoute(
                name: "GetMethod2",
                routeTemplate: "api/infoperson/{name}",
                defaults: new { controller = "InfoPerson", name = UrlParameter.Optional}
                );

        }
    }
}
