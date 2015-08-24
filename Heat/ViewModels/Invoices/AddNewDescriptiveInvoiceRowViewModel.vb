Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class AddNewDescriptiveInvoiceRowViewModel
        Property InvoiceID As Integer

        <Required> _
        <Display(Name:="Descrizione")> _
        Property RowDescription As String

        <Required> _
        <Display(name:="Quantità")> _
        <Range(0, Integer.MaxValue)> _
        Property Quantity As Single

        <Display(name:="Prezzo")> _
        <DataType(DataType.Currency)> _
        Property UnitPrice As Decimal

        <Display(name:="IVA")> _
        Property VAT As Double

        <Display(name:="Sconto 1")> _
        Property Discount1 As Single

        <Display(name:="Sconto 2")> _
        Property Discount2 As Single

        <Display(name:="Sconto 3")> _
        Property Discount3 As Single


    End Class
End Namespace

