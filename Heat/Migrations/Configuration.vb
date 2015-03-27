Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of HeatDBContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            'ContextKey = "Heat.HeatDBContext"
            ContextKey = "Heat"
        End Sub

        Protected Overrides Sub Seed(context As HeatDBContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            Dim manager As New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext))

            Dim demo As New ApplicationUser
            demo.UserName = "demo"

            Dim admin As New ApplicationUser
            admin.UserName = "admin"

            Dim user As New ApplicationUser
            user.UserName = "user"

            manager.Create(demo, "demo")
            manager.Create(admin, "admin")
            manager.Create(user, "user")

        End Sub

    End Class

End Namespace
