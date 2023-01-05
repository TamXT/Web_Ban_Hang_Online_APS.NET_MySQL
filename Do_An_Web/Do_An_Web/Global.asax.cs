using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using System.Web.Optimization;
using System.Web.Routing;
using Do_An_Web.App_Start;

namespace Do_An_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleCollection bundles = BundleTable.Bundles;
            BundleConfig.RegisterBundle(bundles);
        }
    }
}
