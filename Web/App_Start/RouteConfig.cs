using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Clover.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ArticleList",
                url: "Article/Index{id}.html",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "ArticleDetail",
                url: "Article/Detail{id}.html",
                defaults: new { controller = "Article", action = "Detail", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Views",
                url: "Views/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}