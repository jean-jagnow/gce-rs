using System.Web;
using System.Web.Optimization;

namespace GCEWeb
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/lib/jquery/jquery.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/lib/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js",
                        "~/Content/lib/jquery-validate/jquery.validate.min.js",
                        "~/Content/lib/jquery-validate/localization/messages_pt_BR.min.js",
                        "~/Content/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/lib/bootstrap/js/bootstrap.bundle.min.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/lib/bootstrap/css/bootstrap.css",
                      "~/Content/css/app.css"));


            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Content/lib/datatables/datatables.min.js",
                      "~/Content/scripts/gce-datatables.js"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/lib/datatables/datatables.css"));
        }
    }
}
