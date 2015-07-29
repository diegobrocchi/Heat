Imports System.ComponentModel.DataAnnotations


Namespace ViewModels.Invoices
    Public Class InvoiceRowViewModel

        <Key> _
        Property ID As Integer

        Property InvoiceID As Integer

        <Display(name:="Item")> _
        Property Item As Integer

        <Display(name:="Prodotto")> _
        Property Product As String

        <Display(name:="Quantità")> _
        Property Quantity As Single

        <Display(name:="Prezzo")> _
        Property UnitPrice As Decimal

        <Display(name:="IVA")> _
        Property VAT As Single

        <Display(name:="Sconto 1")> _
        Property Discount1 As Single

        <Display(name:="Sconto 2")> _
        Property Discount2 As Single

        <Display(name:="Sconto 3")> _
        Property Discount3 As Single

        <Display(name:="Totale imponibile")> _
        Property TotalBeforeTax As Decimal

        <Display(name:="TOTALE")> _
        Property Total As Decimal


    End Class

End Namespace
