using System.Web;
using System.Web.Optimization;

namespace Web.CredBox
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.10.3.custom.min.js"
                        )
                        
                        );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Global.css",
                "~/Content/css/jquery-ui-1.10.3.custom.min.css"
               ));
        }
    }
}