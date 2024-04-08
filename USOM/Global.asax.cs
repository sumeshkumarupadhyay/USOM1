using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace USOM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public void Application_EndRequest(object sender, EventArgs e)
        {

            if (Response.StatusCode == 413 && Response.SubStatusCode == 1)
            {
                Response.Write("Sorry, File is too big. Max size is 1MB");
                Response.End();
            }
        }
    }
}
