Namespace Models

    Public Class Invoice

        Property ID As Integer
        ''' <summary>
        ''' Numero di serie del documento non appena viene inserito
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property InsertedNumber As SerialNumber

        ''' <summary>
        ''' Numero di serie del documento quando viene confermato
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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
