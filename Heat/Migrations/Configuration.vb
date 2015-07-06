Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Heat.Repositories
Imports System.Security.Claims
Imports System.Data.Entity.Validation

Namespace Migrations

    Public NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of HeatDBContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            AutomaticMigrationDataLossAllowed = True
            ContextKey = "Heat.HeatDBContext"
        End Sub

        Public Sub InitializeIdentity(context As HeatDBContext)
            Dim rm As HeatRoleManager = New HeatRoleManager(New RoleStore(Of HeatRole)(context)) '( HttpContext.Current.GetOwinContext().Get(Of HeatRoleManager)()
            Dim us As UserStore(Of HeatUser) = New UserStore(Of HeatUser)(context)
            'Dim um As HeatUserManager = New HeatUserManager(New UserStore(Of HeatUser)(context)) 'context.GetUserManager(Of HeatUserManager)()
            Dim um As HeatUserManager = New HeatUserManager(us)   'context.GetUserManager(Of HeatUserManager)()



            Const demoName As String = "demo"
            Const demoPassword As String = "demodemo"
            Const CAN_VIEW As String = "canView"

            Const adminName As String = "admin"
            Const adminPassword As String = "adminadmin"
            Const CAN_EDIT As String = "canEdit"

            Const CAN_VIEW_FUELS As String = "canViewFuels"


            Dim canViewRole = rm.FindByName(CAN_VIEW)
            If IsNothing(canViewRole) Then
                canViewRole = New HeatRole(CAN_VIEW, "Pu� visualizzare")
                Dim result = rm.Create(canViewRole)
            End If

            Dim canViewFuelsRole = rm.FindByName(CAN_VIEW_FUELS)
            If IsNothing(canViewFuelsRole) Then
                canViewFuelsRole = New HeatRole(CAN_VIEW_FUELS, "Pu� visualizzare i carburanti")
                Dim result = rm.Create(canViewFuelsRole)
            End If

            Dim demoUser = um.FindByName(demoName)
            If IsNothing(demoUser) Then
                demoUser = New HeatUser With {.UserName = demoName}
                Dim result = um.Create(demoUser, demoPassword)
                result = um.SetLockoutEnabled(demoUser.Id, False)
                Dim cl As New Claim("http://scheme.diegobrocchi.it/claims/2015/operation", ResourceOperations.Execute, "ResourceOperations")
                um.AddClaim(demoUser.Id, cl)
            End If

            Dim RolesForUser = um.GetRoles(demoUser.Id)
            If Not RolesForUser.Contains(canViewRole.Name) Then
                Dim result = um.AddToRole(demoUser.Id, canViewRole.Name)

            End If

            Dim canEditRole = rm.FindByName(CAN_EDIT)
            If IsNothing(canEditRole) Then
                canEditRole = New HeatRole(CAN_EDIT, "Pu� modificare")
                Dim result = rm.Create(canEditRole)
            End If

            Dim admUser = um.FindByName(adminName)
            If IsNothing(admUser) Then
                admUser = New HeatUser With {.UserName = adminName}
                Dim result = um.Create(admUser, adminPassword)
                result = um.SetLockoutEnabled(admUser.Id, False)

                Dim cl1 As New Claim(ClaimTypes.Country, "italy")
                um.AddClaim(admUser.Id, cl1)
            End If

            RolesForUser = um.GetRoles(admUser.Id)
            If Not RolesForUser.Contains(canEditRole.Name) Then
                Dim result = um.AddToRole(admUser.Id, canEditRole.Name)
                result = um.AddToRole(admUser.Id, canViewRole.Name)
            End If
            If Not RolesForUser.Contains(canViewRole.Name) Then
                Dim result = um.AddToRole(admUser.Id, canEditRole.Name)
            End If
            If Not RolesForUser.Contains(canViewFuelsRole.Name) Then
                Dim result = um.AddToRole(admUser.Id, canViewFuelsRole.Name)
            End If


             



        End Sub

        Protected Function AddUserAndRole(context As HeatDBContext) As Boolean
            Dim ir As IdentityResult
            Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(context))
            ir = rm.Create(New HeatRole("canEdit", "Pu� Modificare 99"))
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

            InitializeIdentity(context)

            Dim Fuel1 As New Models.Fuel
            Dim Fuel2 As New Models.Fuel
            Dim Fuel3 As New Models.Fuel

            Dim CausalDocument1 As New Models.CausalDocument
            Dim CausalDocument2 As New Models.CausalDocument
            Dim CausalDocument3 As New Models.CausalDocument

            Dim Payment1 As New Models.Payment
            Dim Payment2 As New Models.Payment
            Dim Payment3 As New Models.Payment

            Dim DittaMC As New Models.Seller

            Dim FTC As New Models.DocumentType
            Dim simpleSchema As New Models.SerialScheme
            Dim number As New Models.Numbering


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


            DittaMC.FiscalCode = "ABCDEFGHILMNOPQRSTUVZ"
            DittaMC.IBAN = "IT000000000000000"
            DittaMC.Logo = "LogoMC.jpg"
            DittaMC.Name = "MC Assistenza Srl di Mauro Cedro"
            DittaMC.Vat_Number = "1234567890"
            DittaMC.Address = New Models.Address With {.StreetNumber = "Via Rossi, 23", .City = "Mandello"}

            number.Code = "FTC"
            number.Description = "Numeratore FTC"
            number.FinalSerialSchema = simpleSchema
            number.TempSerialSchema = simpleSchema
            number.LastTempSerial = New Models.SerialNumber With {.SerialInteger = 0, .SerialString = "0", .IsValid = True}
            number.LastFinalSerial = New Models.SerialNumber With {.SerialInteger = 0, .SerialString = "0", .IsValid = True}

            simpleSchema.Description = "Schema semplice"
            simpleSchema.Increment = 1
            simpleSchema.InitialValue = 1
            simpleSchema.Period = Periodicity.None
            simpleSchema.Name = "INC_1"

            FTC.Name = "FTC"
            FTC.Description = "Fattura Cliente"
            FTC.Numbering = number

            context.CausalDocuments.AddOrUpdate(Function(c) c.Code, CausalDocument1)
            context.CausalDocuments.AddOrUpdate(Function(c) c.Code, CausalDocument2)
            context.CausalDocuments.AddOrUpdate(Function(c) c.Code, CausalDocument3)

            context.Fuels.AddOrUpdate(Function(f) f.Name, Fuel1)
            context.Fuels.AddOrUpdate(Function(f) f.Name, Fuel2)
            context.Fuels.AddOrUpdate(Function(f) f.Name, Fuel3)

            context.Payments.AddOrUpdate(Function(p) p.Code, Payment1)
            context.Payments.AddOrUpdate(Function(p) p.Code, Payment2)
            context.Payments.AddOrUpdate(Function(p) p.Code, Payment3)

            context.Seller.AddOrUpdate(Function(s) s.Name, DittaMC)

            context.SerialSchemes.AddOrUpdate(Function(ss) ss.Name, simpleSchema)
            context.Numberings.AddOrUpdate(Function(n) n.Code, number)
            context.DocumentTypes.AddOrUpdate(Function(dt) dt.Name, FTC)


            context.SaveChanges()


        End Sub

    End Class

End Namespace
