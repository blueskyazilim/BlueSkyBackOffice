namespace BlueSky.Common.WebFramework.Routes
{
    using System;
    using System.Web.Routing;

    public interface IRouteProvider
    {
        int Priority { get; }

        void RegisterRoutes(RouteCollection routes);
    }
}
