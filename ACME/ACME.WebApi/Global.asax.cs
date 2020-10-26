using ACME.WebApi.App_Start;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Optimization;

namespace ACME.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Web.Mvc.AreaRegistration.RegisterAllAreas();
            WebApiConfig.Initialize(IocApiConfig.Instance.Resolve<IDependencyResolver>());
            FilterConfig.RegisterGlobalFilters(System.Web.Mvc.GlobalFilters.Filters);

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
           );

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
