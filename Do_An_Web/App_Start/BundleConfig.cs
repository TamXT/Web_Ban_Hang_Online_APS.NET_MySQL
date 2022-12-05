using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Do_An_Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            //css public
            bundle.Add(new StyleBundle("~/bundles/css1").Include("~/Content/owl.carousel.min.css",
                                                                 "~/Content/animate.min.css",
                                                                 "~/Assets/Client/css/bootstrap.min.css",
                                                                 "~/Assets/Client/css/style.css"));
            //css Admin
            bundle.Add(new StyleBundle("~/bundles/css2").Include("~/Content/bootstrap.min.css",
                                                                 "~/Content/font-awesome.min.css",
                                                                 "~/Content/ionicons.min.css",
                                                                 "~/Content/AdminLTE.min.css",
                                                                 "~/Content/_all-skins.min.css"));
            //Script public
            bundle.Add(new StyleBundle("~/bundles/script1").Include("~/Assets/Client/lib/wow/wow.min.js",
                                                                    "~/Assets/Client/lib/easing/easing.min.js",
                                                                    "~/Assets/Client/lib/waypoints/waypoints.min.js",
                                                                    "~/Assets/Client/lib/owlcarousel/owl.carousel.min.js",
                                                                    "~/Assets/Client/js/main.js"));

            //Script Admin
            bundle.Add(new StyleBundle("~/bundles/script2").Include("~/Scripts/jquery.min.js",
                                                                    "~/Scripts/bootstrap.min.js", 
                                                                    "~/Scripts/jquery.slimscroll.min.js",
                                                                    "~/Scripts/fastclick.js",
                                                                    "~/ Scripts / adminlte.min.js",
                                                                    "~/Scripts/jquery.dataTables.min.js",
                                                                    "~/Scripts/dataTables.bootstrap.min.js",
                                                                    "~/Scripts/demo.js"));
        }

        
    }
}