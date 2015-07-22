Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/DataTables-1.10.5/media/js/jquery.dataTables.js",
                    "~/Scripts/dataTables.bootstrap.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/scripts/jquery.validate.js",
        "~/scripts/jquery.validate.unobtrusive.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css",
                  "~/Content/dataTables.bootstrap.css"))
        

        BundleTable.EnableOptimizations = False

    End Sub
End Module

