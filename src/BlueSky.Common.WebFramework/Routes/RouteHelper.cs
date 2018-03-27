namespace BlueSky.Common.WebFramework.Routes
{
    using Core.Helpers;
    using Core.Reflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Routing;

    public class RouteHelper : IHelper
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            var routeProviderTypes = ClassHarvester.GetConcreteSubclassesOf<IRouteProvider>();
            var routeProviders = new List<IRouteProvider>();

            foreach (var routeProviderType in routeProviderTypes)
            {
                var routeProviderInstance = Activator.CreateInstance(routeProviderType);

                if (routeProviderInstance != null)
                {
                    routeProviders.Add(routeProviderInstance as IRouteProvider);
                }
            }

            routeProviders = routeProviders.OrderByDescending(x => x.Priority).ToList();

            routeProviders.ForEach(rp => rp.RegisterRoutes(routes));
        }
    }
}
