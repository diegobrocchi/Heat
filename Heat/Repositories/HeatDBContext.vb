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

            '_logger = LogManager.GetLogger(GetType(HeatDBContext))
            '_logger.Debug("HeatDbContext created")

        End Sub


        Public Shared Function Create() As HeatDBContext
            Return New HeatDBContext()
        End Function

        Public Sub SetModified(entity As Object) Implements IHeatDBContext.SetModified
            Entry(entity).State = EntityState.Modified
        End Sub

        Property Customers As DbSet(Of Customer) Implements IHeatDBContext.Customers
        Property Address As DbSet(Of Address) Implements IHeatDBContext.Addresses
        Property AddressTypes As DbSet(Of AddressType) Implements IHeatDBContext.AddressTypes
        Property Contacts As DbSet(Of Contact) Implements IHeatDBContext.Contacts
        Property WarehouseMovement As DbSet(Of WarehouseMovement) Implements IHeatDBContext.WarehouseMovements
        Property Plants As DbSet(Of Plant) Implements IHeatDBContext.Plants
        Property PlantTypes As DbSet(Of PlantType) Implements IHeatDBContext.PlantTypes
        Property PlantClasses As DbSet(Of PlantClass) Implements IHeatDBContext.PlantClasses
        Property Invoices As DbSet(Of Invoice) Implements IHeatDBContext.Invoices
        Property InvoiceRows As DbSet(Of InvoiceRow) Implements IHeatDBContext.InvoiceRows
        Property Payments As DbSet(Of Payment) Implements IHeatDBContext.Payments
        Property Fuels As DbSet(Of Fuel) Implements IHeatDBContext.Fuels
        Property CausalDocuments As DbSet(Of CausalDocument)
        Property Numberings As DbSet(Of Numbering) Implements IHeatDBContext.Numberings
        Property DocumentTypes As DbSet(Of Models.DocumentType) Implements IHeatDBContext.DocumentTypes
        Property SerialSchemes As DbSet(Of Models.SerialScheme) Implements IHeatDBContext.SerialSchemes
        Property Warehouses As DbSet(Of Warehouse) Implements IHeatDBContext.Warehouses
        Property CausalWarehouseGroups As DbSet(Of CausalWarehouseGroup) Implements IHeatDBContext.CausalWarehouseGroups
        Property CausalWarehouses As DbSet(Of CausalWarehouse) Implements IHeatDBContext.CausalWarehouses
        Property Seller As DbSet(Of Seller) Implements IHeatDBContext.Sellers
        Property Products As DbSet(Of Product) Implements IHeatDBContext.Products
        Property DescriptiveInvoiceRows As DbSet(Of DescriptiveInvoiceRow) Implements IHeatDBContext.DescriptiveInvoiceRows
        Property ProductInvoiceRows As DbSet(Of ProductInvoiceRow) Implements IHeatDBContext.ProductInvoiceRows
        Property ActionTypes As DbSet(Of Models.ActionType) Implements IHeatDBContext.ActionTypes
        Property WorkOperators As DbSet(Of Models.WorkOperator) Implements IHeatDBContext.WorkOperators
        Property WorkActions As DbSet(Of WorkAction) Implements IHeatDBContext.WorkActions
        Property Operations As DbSet(Of Operation) Implements IHeatDBContext.Operations
        Property Manifacturers As DbSet(Of Manifacturer) Implements IHeatDBContext.Manifacturers
        Property ManifacturerModels As DbSet(Of ManifacturerModel) Implements IHeatDBContext.ManifacturerModels
        Property HeatTransferFluids As DbSet(Of HeatTransferFluid) Implements IHeatDBContext.HeatTransferFluids
        Property ThermalUnits As DbSet(Of Models.ThermalUnit) Implements IHeatDBContext.ThermalUnits
        Property ThermalUnitKinds As DbSet(Of ThermalUnitKind) Implements IHeatDBContext.ThermalUnitKinds
        Property Heaters As DbSet(Of Heater) Implements IHeatDBContext.Heaters
        Property PlantServices As DbSet(Of Models.PlantService) Implements IHeatDBContext.PlantServices

        Property Media As DbSet(Of Medium) Implements IHeatDBContext.Media

        Public Overrides Function SaveChanges() As Integer Implements IHeatDBContext.SaveChanges
            Return MyBase.SaveChanges
        End Function

    End Class

End Namespace


