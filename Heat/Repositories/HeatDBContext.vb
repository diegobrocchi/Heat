Imports System.Data.Entity
Imports Heat.Models
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports log4net


Namespace Repositories

    Public Class HeatDBContext
        Inherits IdentityDbContext(Of HeatUser)
        Implements IHeatDBContext

        Private _logger As ILog

        Sub New()
            MyBase.New("DefaultConnection")
            'Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)
            'Entity.Database.SetInitializer(Of HeatDBContext)(New HeatDBInitializer)
            'Me.Configuration.LazyLoadingEnabled = True
            _logger = LogManager.GetLogger(GetType(HeatDBContext))
            _logger.Info("HeatDbContext created")
        End Sub


        Public Shared Function Create() As HeatDBContext
            Return New HeatDBContext()
        End Function

        Property Customers As DbSet(Of Customer) Implements IHeatDBContext.Customers
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
        Property Numberings As DbSet(Of Numbering) Implements IHeatDBContext.Numberings
        Property DocumentTypes As DbSet(Of Models.DocumentType)
        Property SerialSchemes As DbSet(Of Models.SerialScheme) Implements IHeatDBContext.SerialSchemes


        Public Overrides Function SaveChanges() As Integer Implements IHeatDBContext.SaveChanges
            Return MyBase.SaveChanges
        End Function
 

        Public Property Warehouses As System.Data.Entity.DbSet(Of Warehouse)
    End Class

End Namespace


