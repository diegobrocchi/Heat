Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class HeatUser
    Inherits identityUser

    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of HeatUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity As ClaimsIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        'userIdentity.AddClaims(manager.GetClaims(userIdentity.GetUserId))
        'Threading.Thread.CurrentPrincipal = New ClaimsPrincipal(userIdentity)
        Return userIdentity
    End Function
End Class

Public Class HeatRole
    Inherits IdentityRole

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(rolename As String, description As String)
        MyBase.New(rolename)
        Me.description = description
    End Sub

    Property Description As String
End Class

'Public Class HeatIdentityDbContext
'    Inherits IdentityDbContext(Of HeatUser)
'    Public Sub New()
'        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
'        Entity.Database.SetInitializer(Of HeatIdentityDbContext)(New HeatDBInitializer)
'    End Sub

'    Public Shared Function Create() As HeatIdentityDbContext
'        Return New HeatIdentityDbContext()
'    End Function
'End Class

