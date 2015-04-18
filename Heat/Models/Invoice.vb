Namespace Models

    Public Class Invoice

        Property ID As Integer
        Property DocNumber As Integer

        Property Customer As Customer
        Property Sum As Decimal
        Property InvoiceRows As List(Of InvoiceRow)
        Property Payment As Payment
        'Property CausalWarehouse As CausalWarehouse

    End Class
End Namespace
