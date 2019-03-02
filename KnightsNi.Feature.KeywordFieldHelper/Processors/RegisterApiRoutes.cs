using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace Knights.Feature.KeywordFieldHelper.Processors
{
    public class RegisterApiRoutes
    {
        public void Process(PipelineArgs args)
        {
            //recommended way to register custom routes within Sitecore.
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                //register MVC/AJAX route(s)
                routes.MapRoute("Keywords", "Keywords/Get/{id}", new { controller = "Keywords", action = "Get", id = UrlParameter.Optional });
            }
        }
    }
}