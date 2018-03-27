namespace BlueSky.Commerce.WebUI
{
    using Common.WebFramework.Routes;
    using Core.Helpers;
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Hel.per<RouteHelper>().RegisterRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BlueSky.Commerce.WebUI.Controllers" }
            );
        }
    }
}
