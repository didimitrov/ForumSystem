﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ForumSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Get questions by tag",
              url: "questions/tagged/{tag}",
              defaults: new { controller = "Questions", action = "GetByTag" }
          );

            routes.MapRoute(
               name: "Display questions",
               url: "questions/{id}/{url}",
               defaults: new { controller = "Questions", action = "Display"}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
