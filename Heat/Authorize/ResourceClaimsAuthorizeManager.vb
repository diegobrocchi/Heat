Imports System.Security.Claims
Imports Heat.Repositories

Public Class ResourceClaimsAuthorizeManager
    Inherits ClaimsAuthorizationManager

    Private _db As HeatDBContext

    Sub New()
    End Sub

    Sub New(dbContext As HeatDBContext)
        _db = dbContext
    End Sub

    Public Overrides Function CheckAccess(context As AuthorizationContext) As Boolean
        Dim resource = context.Resource.First
        Dim claims = context.Principal.Claims.ToList
        Dim action = context.Action.First

        'http://stackoverflow.com/questions/26464848/custom-authorization-in-asp-net-webapi-what-a-mess
        Dim authRequired As ResourceOperations

        authRequired = [Enum].Parse(GetType(ResourceOperations), action.Value)

        For Each Claim In claims
            If Claim.Type = "http://scheme.diegobrocchi.it/claims/2015/operation" Then
                Dim authOwned As ResourceOperations = [Enum].Parse(GetType(ResourceOperations), Claim.Value)
                If authOwned And authRequired = authRequired Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function



End Class
