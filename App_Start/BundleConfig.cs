using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonelMVCUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.0.0.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/sipahi.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Scripts/jquery-3.0.0.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/sipahi.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ));
        }
    }
}