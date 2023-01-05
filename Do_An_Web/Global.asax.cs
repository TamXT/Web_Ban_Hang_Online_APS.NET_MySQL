using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using System.Web.Optimization;
using System.Web.Routing;
using Do_An_Web.App_Start;
using Do_An_Web.Models;

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
        protected void Session_Strart(Object sender, EventArgs e)
        {
            Session["TtDangNhap"] = new TaiKhoan();
            Session["GioHang"] = new CartShop();
        }

    }
}
