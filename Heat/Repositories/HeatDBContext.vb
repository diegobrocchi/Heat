Imports System.Data.Entity
Imports Heat.Models

Public Class HeatDBContext
    Inherits DbContext

    Sub New()
        'Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)
    End Sub

    Property Customers As DbSet(Of Customer)
    Property Address As DbSet(Of Address)
    Property Actions As DbSet(Of Action)
    Property InventoryMovement As DbSet(Of InventoryMovement)
    Property Plants As DbSet(Of Plant)
    Property PlantTypes As DbSet(Of PlantType)
    Property PlantClasses As DbSet(Of PlantClass)


End Class
