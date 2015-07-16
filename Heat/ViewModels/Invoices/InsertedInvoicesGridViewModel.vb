Imports System.ComponentModel.DataAnnotations


Namespace ViewModels.Invoices
    Public Class InsertedInvoicesGridViewModel
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property Customer As String

        <Display(name:="Data emissione")> _
        Property InvoiceDate As DateTime

        <Display(name:="Numero Provvisorio")> _
        Property InvoiceNumber As String

        <Display(name:="Importo")> _
        Property Total As Decimal
    End Class

End Namespace
