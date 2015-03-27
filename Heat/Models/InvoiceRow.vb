Namespace Models
    Public Class InvoiceRow
        Property ID As Integer
        Property Invoice As Invoice
        Property RowID As Integer
        Property ItemOrder As Integer
        Property Product As Product
        Property Quantity As Double
        Property UnitPrice As Decimal
        Property VAT As Double
        ReadOnly Property NetRowTotal As Decimal
            Get
                Return UnitPrice * Quantity
            End Get
        End Property
        ReadOnly Property GrossRowTotal As Decimal
            Get
                Return NetRowTotal * (1 + VAT)
            End Get
        End Property
    End Class

End Namespace

