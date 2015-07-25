Imports System.ComponentModel.DataAnnotations


Namespace ViewModels
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

    End Class

End Namespace
