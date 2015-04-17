Namespace Models

    Public Class WarehouseMovement

        Property ID As Integer
        Property Product As Product
        Property Quantity As Double
        Property ExecDate As Date
        Property Note As String
        'Property Causation As CausalWarehouse
        Property Source As Warehouse
        Property Destination As Warehouse

    End Class
End Namespace
