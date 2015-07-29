Imports System.ComponentModel.DataAnnotations
Imports Heat.ViewModels

Namespace ViewModels.Invoices

    Public Class InvoicePaymentViewModel

        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Numero fattura provvisoria")> _
        Property InvoiceNumber As String

        <Display(name:="Data documento")> _
        Property InvoiceDate As String

        Property Rows As List(Of InvoiceRowViewModel)

        <Required> _
        <Display(name:="Condizioni di pagamento")> _
        Property PaymentID As Integer

        Property PaymentList As IEnumerable(Of SelectListItem)

        <Display(name:="Fattura esente")> _
        Property IsTaxExempt As Boolean

        <Display(name:="Esenzione")> _
        Property TaxExemption As String


    End Class

End Namespace
