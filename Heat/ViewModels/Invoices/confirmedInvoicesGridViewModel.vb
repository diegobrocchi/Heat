Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class confirmedInvoicesGridViewModel
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property Customer As String

        <Display(name:="Data emissione")> _
        Property InvoiceDate As DateTime

        <Display(name:="Numero")> _
        Property InvoiceNumber As String

        <Display(name:="Importo")> _
        Property Total As Decimal

    End Class
End Namespace

