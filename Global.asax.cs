using PersonelMVCUI.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonelMVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //bu satýrý ekledik.

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //bu satýrý ekledik. ayrýca Views altýndaki web.confige de bunu ekledik: <add namespace="System.Web.Optimization"/>
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
            
        }
    }
}
