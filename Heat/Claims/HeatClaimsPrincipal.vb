Imports System.Security.Claims
Imports System.Security.Principal

Public Class HeatClaimsPrincipal
    Inherits ClaimsPrincipal

    Sub New(username As String)
        Dim gi As GenericIdentity = New GenericIdentity(username, "Heat Custom authentication")
        Dim ci As ClaimsIdentity = New ClaimsIdentity(gi)

        Me.AddIdentity(ci)
    End Sub


End Class
