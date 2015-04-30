Imports Heat.Repositories
Imports Heat.Controllers
Imports Microsoft.Owin
Imports Microsoft.AspNet.Identity.Owin
Imports System.Security.Claims
Imports System.Web.Security
Imports System.Collections.ObjectModel




<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method, inherited:=True, AllowMultiple:=True)> _
Public Class ResourceAuthorizeAttribute
    Inherits AuthorizeAttribute

    Private _operation As ResourceOperations
    Private _resource As String

    Public Sub New(Operation As ResourceOperations, Resource As String)
        _operation = Operation
        _resource = Resource
    End Sub
     

    Public Overrides Sub OnAuthorization(filterContext As Mvc.AuthorizationContext)
        Dim dbContext = filterContext.HttpContext.GetOwinContext().Get(Of HeatDBContext)()
        Dim cm As New ResourceClaimsAuthorizeManager(dbContext)

        Dim p As ClaimsPrincipal = DirectCast(filterContext.HttpContext.User, ClaimsPrincipal)
        Dim resourceClaims As New Collection(Of Claim)
        Dim operationClaims As New Collection(Of Claim)

        resourceClaims.Add(New Claim("http://scheme.diegobrocchi.it/claims/2015/resource", _resource))
        operationClaims.Add(New Claim("http://scheme.diegobrocchi.it/claims/2015/operation", _operation, "ResourceOperations"))

        If cm.CheckAccess(New AuthorizationContext(DirectCast(filterContext.HttpContext.User, ClaimsPrincipal), resourceClaims, operationClaims)) Then
            MyBase.OnAuthorization(filterContext)
        Else
            MyBase.HandleUnauthorizedRequest(filterContext)

        End If

    End Sub

     

End Class
