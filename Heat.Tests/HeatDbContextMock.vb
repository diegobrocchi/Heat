Imports System.Data.Entity
Imports Heat
Imports Heat.Models

'https://visualstudiomagazine.com/articles/2014/06/01/test-driven-development.aspx

Public Class HeatDbContextMock
    Implements IHeatDBContext

    Public Property Numberings As Entity.DbSet(Of Models.Numbering) Implements IHeatDBContext.Numberings
    Public Property SerialScheme As Entity.DbSet(Of Models.SerialScheme) Implements IHeatDBContext.SerialSchemes
    Public Property Customers As Entity.DbSet(Of Models.Customer) Implements IHeatDBContext.Customers


    Public Sub New()
        Customers = New CustomerMockDbSet
        DocumentTypes = New DocumentTypeMockDbSet
        Invoices = New TestDbSet(Of Invoice)
        init()
    End Sub

    Public Sub init()
        Dim num As New Numbering
        num.Code = "HHH"
        num.TempSerialSchema = New SerialScheme With {.Increment = 1, .InitialValue = 1, .Period = Periodicity.None}
        num.LastTempSerial = New SerialNumber With {.SerialInteger = 0, .SerialString = "0", .IsValid = True}
        DocumentTypes.Add(New Models.DocumentType With {.Name = "FTC", .Numbering = num})
    End Sub
    Public Function SaveChanges() As Integer Implements IHeatDBContext.SaveChanges
        Return 0
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Property CausalWarehouseGroups As Entity.DbSet(Of CausalWarehouseGroup) Implements IHeatDBContext.CausalWarehouseGroups

    Public Property CausalWarehouses As Entity.DbSet(Of CausalWarehouse) Implements IHeatDBContext.CausalWarehouses

    Public Sub SetModified(entity As Object) Implements IHeatDBContext.SetModified

    End Sub

    Public Property Warehouses As Entity.DbSet(Of Models.Warehouse) Implements IHeatDBContext.Warehouses

    Public Property WarehouseMovement As Entity.DbSet(Of Models.WarehouseMovement) Implements IHeatDBContext.WarehouseMovements

    Public Property Seller As Entity.DbSet(Of Models.Seller) Implements IHeatDBContext.Sellers

    Public Property Invoices As Entity.DbSet(Of Models.Invoice) Implements IHeatDBContext.Invoices

    Public Property DocumentTypes As Entity.DbSet(Of Models.DocumentType) Implements IHeatDBContext.DocumentTypes

    Public Property InvoiceRows As Entity.DbSet(Of InvoiceRow) Implements IHeatDBContext.InvoiceRows

    Public Property Products As Entity.DbSet(Of Product) Implements IHeatDBContext.Products

    Public Property Payments As Entity.DbSet(Of Payment) Implements IHeatDBContext.Payments

    Public Property DescriptiveInvoiceRows As Entity.DbSet(Of DescriptiveInvoiceRow) Implements IHeatDBContext.DescriptiveInvoiceRows

    Public Property ProductInvoiceRows As Entity.DbSet(Of ProductInvoiceRow) Implements IHeatDBContext.ProductInvoiceRows

    Public Property ActionTypes As Entity.DbSet(Of ActionType) Implements IHeatDBContext.ActionTypes

    Public Property WorkOperators As Entity.DbSet(Of WorkOperator) Implements IHeatDBContext.WorkOperators

    Public Property Manifacturers As Entity.DbSet(Of Manifacturer) Implements IHeatDBContext.Manifacturers

    Public Property ManifacturerModels As Entity.DbSet(Of ManifacturerModel) Implements IHeatDBContext.ManifacturerModels

    Public Property HeatTransferFluids As Entity.DbSet(Of HeatTransferFluid) Implements IHeatDBContext.HeatTransferFluids

    Public Property ThermalUnitKinds As Entity.DbSet(Of ThermalUnitKind) Implements IHeatDBContext.ThermalUnitKinds

    Public Property PlantClasses As Entity.DbSet(Of PlantClass) Implements IHeatDBContext.PlantClasses

    Public Property Plants As Entity.DbSet(Of Plant) Implements IHeatDBContext.Plants

    Public Property PlantTypes As Entity.DbSet(Of PlantType) Implements IHeatDBContext.PlantTypes

    Public Property Fuels As Entity.DbSet(Of Fuel) Implements IHeatDBContext.Fuels

    Public Property ThermalUnits As Entity.DbSet(Of ThermalUnit) Implements IHeatDBContext.ThermalUnits

    Public Property Heaters As Entity.DbSet(Of Heater) Implements IHeatDBContext.Heaters

    Public Property PlantServices As Entity.DbSet(Of PlantService) Implements IHeatDBContext.PlantServices

    Public Property WorkActions As Entity.DbSet(Of WorkAction) Implements IHeatDBContext.WorkActions

    Public Property Operations As Entity.DbSet(Of Operation) Implements IHeatDBContext.Operations

    Public Property Contacts As Entity.DbSet(Of Contact) Implements IHeatDBContext.Contacts

    Public Property Addresses As Entity.DbSet(Of Address) Implements IHeatDBContext.Addresses

    Public Property AddressTypes As Entity.DbSet(Of AddressType) Implements IHeatDBContext.AddressTypes

    Public Property Media As DbSet(Of Medium) Implements IHeatDBContext.Media
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As DbSet(Of Medium))
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property OutboundCalls As DbSet(Of OutboundCall) Implements IHeatDBContext.OutboundCalls
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As DbSet(Of OutboundCall))
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ProposedOutboundCalls As DbSet(Of ProposedOutBoundCall) Implements IHeatDBContext.ProposedOutboundCalls
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As DbSet(Of ProposedOutBoundCall))
            Throw New NotImplementedException()
        End Set
    End Property
End Class
