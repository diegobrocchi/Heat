Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of HeatDBContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            ContextKey = "Heat.HeatDBContext"
        End Sub

        Protected Overrides Sub Seed(context As HeatDBContext)
            Debug.Print("Seeding...")
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            context.Payments.AddOrUpdate(New Models.Payment With {.Code = "RIBA99", .Description = "Ricevuta bancaria 99 giorni fine mese"})
            context.SaveChanges()

            Using manager = New HeatUserManager(New UserStore(Of HeatUser)(New HeatIdentityDbContext))

                Dim admin As New HeatUser
                Dim demo As New HeatUser

                admin.UserName = "admin"
                demo.UserName = "demo"

                manager.Create(admin, "admin")
                manager.Create(demo, "demo")

            End Using



        End Sub

    End Class

End Namespace
