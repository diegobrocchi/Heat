Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    ''' <summary>
    ''' Una riga fattura intesa come modello da presentare nella view: la fattura ha righe che possono essere di tipo differente: Prodotto o Descrittiva.
    ''' Una riga di tipo Presentation costituisce una versione omogenea, di sola lettura, per i due tipi.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PresentationInvoiceRowViewModel
        'Inherits Models.InvoiceRow

        'le proprietà ID + RowType costituiscono la chiave primaria dell'entità.

        Property RowType As InvoiceRowType

        Property ProductCode As String
        Property Description As String

        <Key> _
        Property ID As Integer

        Property InvoiceID As Integer

        <Display(name:="Item")> _
        Property Item As Integer

        <Display(name:="Codice")> _
        Property SKU As String

        <Display(name:="Prodotto")> _
        Property Product As String

        <Display(name:="Quantità")> _
        Property Quantity As Single

        <Display(name:="Prezzo")> _
        Property UnitPrice As Decimal

        <Display(name:="IVA")> _
        Property VAT As Double

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

    Public Enum InvoiceRowType
        DescriptiveRow = 0
        ProductRow = 1
    End Enum
End Namespace

