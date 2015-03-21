Namespace Models

    Public Class InventoryMovement
        Property ID As Integer
        Property Product As Product
        Property Quantity As Double
        Property ExecDate As Date
        Property Note As String
        Property Causation As Causation
        Property SourceDeposit As Deposit
        Property DestinationDeposit As Deposit


    End Class
End Namespace
