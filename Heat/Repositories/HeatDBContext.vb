Imports System.Data.Entity
Imports Heat.Models
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports log4net


Namespace Repositories

    Public Class HeatDBContext
        Inherits DbContext

        Private _logger As ILog

        Sub New()
            MyBase.New("DefaultConnection")
            Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)

            _logger = LogManager.GetLogger(GetType(HeatDBContext))
            _logger.Info("HeatDbContext created")
        End Sub

        Property Customers As DbSet(Of Customer)
        Property Address As DbSet(Of Address)
        Property Actions As DbSet(Of Action)
        Property WarehouseMovement As DbSet(Of WarehouseMovement)
        Property Plants As DbSet(Of Plant)
        Property PlantTypes As DbSet(Of PlantType)
        Property PlantClasses As DbSet(Of PlantClass)
        Property Invoices As DbSet(Of Invoice)
        Property Products As DbSet(Of Product)
        Property Payments As DbSet(Of Payment)
        Property Fuels As DbSet(Of Fuel)
        Property CausalDocuments As DbSet(Of CausalDocument)
        Property Numerators As DbSet(Of Numerator)
    End Class

End Namespace


