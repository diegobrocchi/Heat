Imports Heat.Models
Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class EditProductInvoiceRowViewModel
        Property InvoiceID As Integer

        <Key> _
        Property ID As Integer

        <Required> _
        <Display(name:="Prodotto")> _
        Property ProductID As Integer
        Property ProductList As IEnumerable(Of SelectListItem)

        <Required> _
        <Display(name:="Quantità")> _
        <Range(0, Integer.MaxValue)> _
        Property Quantity As Single

        <Display(name:="Prezzo")> _
        <DataType(DataType.Currency)> _
        Property UnitPrice As Decimal

        <Display(name:="IVA")> _
        Property VAT As Single

        <Display(name:="Sconto 1")> _
        Property Discount1 As Single

        <Display(name:="Sconto 2")> _
        Property Discount2 As Single

        <Display(name:="Sconto 3")> _
        Property Discount3 As Single

    End Class
End Namespace

