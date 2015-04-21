Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity
Imports Heat.Repositories

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of HeatDBContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            ContextKey = "Heat.HeatDBContext"
        End Sub

        Protected Function AddUserAndRole(context As HeatIdentityDbContext) As Boolean
            Dim ir As IdentityResult
            Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(context))
            ir = rm.Create(New identityrole("canEdit"))
            Dim um = New HeatUserManager(New UserStore(Of HeatUser)(context))
            Dim user = New HeatUser With {.UserName = "demo"}

            ir = um.Create(user, "demo")
            If ir.Succeeded = False Then
                Return ir.Succeeded
            End If
            ir = um.AddToRole(user.Id, "canEdit")
            Return ir.Succeeded



        End Function

        Protected Overrides Sub Seed(context As HeatDBContext)
            Debug.Print("Seeding...")
            AddUserAndRole(New HeatIdentityDbContext)

            Dim Fuel1 As New Models.Fuel
            Dim Fuel2 As New Models.Fuel
            Dim Fuel3 As New Models.Fuel

            Dim CausalDocument1 As New Models.CausalDocument
            Dim CausalDocument2 As New Models.CausalDocument
            Dim CausalDocument3 As New Models.CausalDocument

            Dim Payment1 As New Models.Payment
            Dim Payment2 As New Models.Payment
            Dim Payment3 As New Models.Payment

            Fuel1.Name = "Gasolio"
            Fuel2.Name = "Metano"
            Fuel3.Name = "Cippato"

            CausalDocument1.Code = "VEN"
            CausalDocument1.Description = "Vendita"

            CausalDocument2.Code = "SER"
            CausalDocument2.Description = "Servizi"

            CausalDocument3.Code = "ACQ"
            CausalDocument3.Description = "Acquisto"

            Payment1.Code = "RIBA30"
            Payment1.Description = "Ricevuta bancaria a 30 giorni"

            Payment2.Code = "RIBA60"
            Payment2.Description = "Ricevuta bancaria a 60 giorni"

            Payment3.Code = "RIBA90"
            Payment3.Description = "Ricevuta bancaria a 90 giorni"

            context.CausalDocuments.AddOrUpdate(CausalDocument1)
            context.CausalDocuments.AddOrUpdate(CausalDocument2)
            context.CausalDocuments.AddOrUpdate(CausalDocument3)

            context.Fuels.AddOrUpdate(Fuel1)
            context.Fuels.AddOrUpdate(Fuel2)
            context.Fuels.AddOrUpdate(Fuel3)

            context.Payments.AddOrUpdate(Payment1)
            context.Payments.AddOrUpdate(Payment2)
            context.Payments.AddOrUpdate(Payment3)


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
