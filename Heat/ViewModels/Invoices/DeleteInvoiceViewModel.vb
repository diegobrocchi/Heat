Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class DeleteInvoiceViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Numero")> _
        Property InvoiceNumber As String

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Data documento")> _
        <DisplayFormat(DataFormatString:="{0:d}")> _
        Property InvoiceDate As DateTime

        Property Rows As List(Of PresentationInvoiceRowViewModel)
        ' Property Rows As List(Of InvoiceRowViewModel)

    End Class
End Namespace

