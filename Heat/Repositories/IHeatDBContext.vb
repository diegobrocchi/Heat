Imports System.Data.Entity
Imports Heat.Models

Public Interface IHeatDBContext
    Inherits IDisposable

    Property Addresses As DbSet(Of Address)
    Property AddressTypes As DbSet(Of AddressType)
    Property Customers As DbSet(Of Customer)
    Property Contacts As DbSet(Of Contact)
    Property Numberings As DbSet(Of Numbering)
    Property SerialSchemes As DbSet(Of SerialScheme)
    Property CausalWarehouses As DbSet(Of CausalWarehouse)
    Property CausalWarehouseGroups As DbSet(Of CausalWarehouseGroup)
    Property Warehouses As DbSet(Of Warehouse)
    Property WarehouseMovements As DbSet(Of WarehouseMovement)
    Property Sellers As DbSet(Of Seller)
    Property Invoices As DbSet(Of Invoice)
    Property InvoiceRows As DbSet(Of InvoiceRow)
    Property DocumentTypes As DbSet(Of DocumentType)
    Property Products As DbSet(Of Product)
    Property Payments As DbSet(Of Payment)
    Property ProductInvoiceRows As DbSet(Of ProductInvoiceRow)
    Property DescriptiveInvoiceRows As DbSet(Of DescriptiveInvoiceRow)
    Property ActionTypes As DbSet(Of ActionType)
    Property WorkOperators As DbSet(Of WorkOperator)
    Property WorkActions As DbSet(Of WorkAction)
    Property Operations As DbSet(Of Operation)
    Property Manifacturers As DbSet(Of Manifacturer)
    Property ManifacturerModels As DbSet(Of ManifacturerModel)
    
    Property HeatTransferFluids As DbSet(Of HeatTransferFluid)
    Property ThermalUnitKinds As DbSet(Of ThermalUnitKind)
    Property Plants As DbSet(Of Plant)
    Property PlantTypes As DbSet(Of PlantType)
    Property PlantClasses As DbSet(Of PlantClass)
    Property PlantServices As DbSet(Of PlantService)
    Property ThermalUnits As DbSet(Of ThermalUnit)
    Property Fuels As DbSet(Of Fuel)
    Property Heaters As DbSet(Of Heater)
    Property Media As DbSet(Of Medium)



    Function SaveChanges() As Integer

    Sub SetModified(entity As Object)

End Interface
