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
        ''' <summary>
        ''' Stato del documento: Inserted, Confirmed o Deleted.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property State As DocumentState
        ''' <summary>
        ''' Ente emittente del documento
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Seller As ISeller
        ''' <summary>
        ''' Soggetto verso cui è emesso il documento.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Customer As Customer
        ''' <summary>
        ''' Data del documento.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property InvoiceDate As Date
        ''' <summary>
        ''' Importo IMPONIBILE totale della fattura: calcolato al momento della conferma del documento come somma dell'IMPONIBILE di ogni riga.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TaxableAmount As Decimal
        Property TaxRate As Decimal
        ''' <summary>
        ''' Importo totale dell'IVA del documento: calcolato al momento della conferma del documento come somma dell'IVA di ogni riga.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TaxesAmount As Decimal
        ''' <summary>
        ''' Importo totale del documento: calcolato al momento della conferma del documento.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TotalAmount As Decimal
        Property SelfBilling As Boolean
        Property IsTaxExempt As Boolean
        Property TaxExemption As String
        Property Payment As Payment

        Property InvoiceRows As List(Of InvoiceRow)

    End Class
End Namespace
