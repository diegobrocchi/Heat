Namespace Models

    Public Class Invoice

        Property ID As Integer
        Property InsertedNumber As SerialNumber
        Property ConfirmedNumber As SerialNumber
        Property State As DocumentState
        Property Seller As ISeller
        Property Customer As Customer
        Property InvoiceDate As Date
        Property TaxableAmount As Decimal
        Property TaxRate As Decimal
        Property TaxesAmount As Decimal
        Property TotalAmount As Decimal
        Property SelfBilling As Boolean
        Property IsTaxExempt As Boolean
        Property TaxExemption As String
        Property Payment As Payment
        Property InvoiceRows As List(Of InvoiceRow)

    End Class
End Namespace
