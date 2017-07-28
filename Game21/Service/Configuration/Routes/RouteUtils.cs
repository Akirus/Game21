using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Game21.Service.Configuration.Routes
{
    public static class RouteUtils
    {

        public static IRouteBuilder MapRoute(this IRouteBuilder routes, RouteInfo routeInfo)
        {
            return routes.MapRoute(routeInfo.Name, routeInfo.Template, routeInfo.Defaults, null);
        }
        
    }
}