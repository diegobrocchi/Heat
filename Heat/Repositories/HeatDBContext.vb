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
            'Entity.Database.SetInitializer(Of HeatDBContext)(New DropCreateDatabaseIfModelChanges(Of HeatDBContext))
            'Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)
            'Entity.Database.SetInitializer(Of HeatDBContext)(New HeatDBInitializer)
            'Me.Configuration.LazyLoadingEnabled = True
            _logger = LogManager.GetLogger(GetType(HeatDBContext))
            _logger.Debug("HeatDbContext created")
        End Sub


        Public Shared Function Create() As HeatDBContext
            Return New HeatDBContext()
        End Function

        Public Sub SetModified(entity As Object) Implements IHeatDBContext.SetModified
            Entry(entity).State = EntityState.Modified
        End Sub

        Property Customers As DbSet(Of Customer) Implements IHeatDBContext.Customers
        Property Address As DbSet(Of Address)
        Property Actions As DbSet(Of WorkAction)
        Property WarehouseMovement As DbSet(Of WarehouseMovement) Implements IHeatDBContext.WarehouseMovements
        Property Plants As DbSet(Of Plant)
        Property PlantTypes As DbSet(Of PlantType)
        Property PlantClasses As DbSet(Of PlantClass)
        Property Invoices As DbSet(Of Invoice) Implements IHeatDBContext.Invoices
        Property InvoiceRows As DbSet(Of InvoiceRow) Implements IHeatDBContext.InvoiceRows
        Property Payments As DbSet(Of Payment) Implements IHeatDBContext.Payments
        Property Fuels As DbSet(Of Fuel)
        Property CausalDocuments As DbSet(Of CausalDocument)
        Property Numberings As DbSet(Of Numbering) Implements IHeatDBContext.Numberings
        Property DocumentTypes As DbSet(Of Models.DocumentType) Implements IHeatDBContext.DocumentTypes
        Property SerialSchemes As DbSet(Of Models.SerialScheme) Implements IHeatDBContext.SerialSchemes
        Property Warehouses As System.Data.Entity.DbSet(Of Warehouse) Implements IHeatDBContext.Warehouses
        Property CausalWarehouseGroups As System.Data.Entity.DbSet(Of CausalWarehouseGroup) Implements IHeatDBContext.CausalWarehouseGroups
        Property CausalWarehouses As System.Data.Entity.DbSet(Of CausalWarehouse) Implements IHeatDBContext.CausalWarehouses
        Property Seller As DbSet(Of Seller) Implements IHeatDBContext.Sellers
        Property Products As DbSet(Of Product) Implements IHeatDBContext.Products
        Property AddressTypes As System.Data.Entity.DbSet(Of Models.AddressType)
        Property Operations As System.Data.Entity.DbSet(Of Models.Operation)
        Property DescriptiveInvoiceRows As DbSet(Of DescriptiveInvoiceRow) Implements IHeatDBContext.DescriptiveInvoiceRows
        Property ProductInvoiceRows As DbSet(Of ProductInvoiceRow) Implements IHeatDBContext.ProductInvoiceRows
        Property ActionTypes As System.Data.Entity.DbSet(Of Models.ActionType) Implements IHeatDBContext.ActionTypes
        Property WorkOperators As System.Data.Entity.DbSet(Of Models.WorkOperator) Implements IHeatDBContext.WorkOperators
        Property Manifacturers As DbSet(Of Manifacturer) Implements IHeatDBContext.Manifacturers
        Property ManifacturerModels As DbSet(Of ManifacturerModel) Implements IHeatDBContext.ManifacturerModels
        Property BoilerHeaters As DbSet(Of BoilerHeater) Implements IHeatDBContext.BoilerHeaters
        Property BoilerServicesTypes As DbSet(Of BoilerServiceType) Implements IHeatDBContext.BoilerServiceTypes

        Public Overrides Function SaveChanges() As Integer Implements IHeatDBContext.SaveChanges
            Return MyBase.SaveChanges
        End Function

    End Class

End Namespace


