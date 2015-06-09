Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class WarehouseMovement

        Property ID As Integer

        'EF by-configuration foreign key
        Property ProductID As Integer
        Property Product As Product

        Property Quantity As Double
        <DataType(DataType.Date), DisplayFormat(dataformatstring:="{0:yyyy-MM-dd}", applyFormatInEditMode:=True)> _
        Property ExecDate As Date
        Property Note As String

        Property SourceID As Integer
        Property Source As Warehouse

        Property DestinationID As Integer
        Property Destination As Warehouse

        Property CausalWarehouseID As Integer
        Property CausalWarehouse As CausalWarehouse

    End Class
End Namespace
