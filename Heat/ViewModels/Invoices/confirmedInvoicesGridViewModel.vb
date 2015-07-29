Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    ''' <summary>
    ''' Un modello per la visualizzazione della griglia delle fatture confermate. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class confirmedInvoicesGridViewModel
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property Customer As String

        <Display(name:="Data emissione")> _
        <DisplayFormat(dataformatstring:="{0:d}")> _
        Property InvoiceDate As DateTime

        <Display(name:="Numero")> _
        Property InvoiceNumber As String

        <Display(name:="TOTALE")> _
        Property TotalAmount As Decimal

        <Display(name:="IVA")> _
        Property TaxesAmount As Decimal

        <Display(name:="Imponibile")> _
        Property TaxableAmount As Decimal

        <Display(name:="Pagamento")> _
        Property Payment As String


    End Class
End Namespace

