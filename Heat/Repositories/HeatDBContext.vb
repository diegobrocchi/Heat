Imports System.Data.Entity
Imports Heat.Models
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class HeatDBContext
    Inherits DbContext

    Sub New()
        MyBase.New("DefaultConnection")
        Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)
    End Sub

    Property Customers As DbSet(Of Customer)
    Property Address As DbSet(Of Address)
    Property Actions As DbSet(Of Action)
    Property InventoryMovement As DbSet(Of InventoryMovement)
    Property Plants As DbSet(Of Plant)
    Property PlantTypes As DbSet(Of PlantType)
    Property PlantClasses As DbSet(Of PlantClass)
    Property Invoices As DbSet(Of Invoice)
    Property Products As DbSet(Of Product)
    Property Payments As DbSet(Of Payment)
    Property Fuels As DbSet(Of Fuel)

End Class



