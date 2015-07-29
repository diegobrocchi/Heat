Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class ConfirmInvoiceViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Numero documento")> _
        Property InvoiceNumber As String

        <Display(name:="Data documento")> _
        Property InvoiceDate As String

        Property Rows As List(Of InvoiceRowViewModel)


        <Display(name:="Condizioni di pagamento")> _
        Property Payment As String


        <Display(name:="Fattura esente")> _
        Property IsTaxExempt As Boolean

        <Display(name:="Esenzione")> _
        Property TaxExemption As String
    End Class
End Namespace

