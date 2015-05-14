Imports System.Web.Optimization
Imports System.Web.Helpers
Imports System.Security.Claims
Imports System.IdentityModel.Services
Imports AutoMapper


Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        'http://www.codeproject.com/Articles/639458/Claims-Based-Authentication-and-Authorization
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name

        Mapper.CreateMap(Of AddNewSerialSchemeViewModel, SerialScheme)().bidirectional()
    End Sub

    'Public Overrides Sub Init()
    '    Dim sam As New SessionAuthenticationModule
    '    sam.IsReferenceMode = True

    'End Sub
End Class
