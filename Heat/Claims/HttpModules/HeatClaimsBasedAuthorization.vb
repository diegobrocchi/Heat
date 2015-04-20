Imports System.Security.Claims

Public Class HeatClaimsBasedAuthorization
    Implements IHttpModule

    Public Sub Dispose() Implements IHttpModule.Dispose

    End Sub

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.PostAuthenticateRequest, AddressOf ReplacePrincipal
    End Sub
    Private Shared Sub ReplacePrincipal()
        If Not IsNothing(HttpContext.Current.User) AndAlso HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim cp As ClaimsPrincipal = CreateClaimsBasedPrincipal()
        End If

    End Sub

    Private Shared Function CreateClaimsBasedPrincipal() As ClaimsPrincipal
        Dim UserName As String = Threading.Thread.CurrentPrincipal.Identity.Name
        Dim hcp As HeatClaimsPrincipal = New HeatClaimsPrincipal(UserName)
        Threading.Thread.CurrentPrincipal = hcp

        If Not IsNothing(HttpContext.Current) Then
            HttpContext.Current.User = hcp
        End If

        Return hcp
    End Function

    
End Class
