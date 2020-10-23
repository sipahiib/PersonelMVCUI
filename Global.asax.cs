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
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //bu sat�r� ekledik.

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //bu sat�r� ekledik. ayr�ca Views alt�ndaki web.confige de bunu ekledik: <add namespace="System.Web.Optimization"/>
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
            
        }
    }
}
