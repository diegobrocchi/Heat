Imports System.ComponentModel.DataAnnotations


Namespace ViewModels.Invoices
    ''' <summary>
    ''' Modello per la visualizzazione della griglia delle fatture inserite (ma non confermate).
    ''' </summary>
    ''' <remarks></remarks>
    Public Class InsertedInvoicesGridViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property Customer As String

        <Display(name:="Data emissione")> _
        <DisplayFormat(dataformatstring:="{0: d}")> _
        Property InvoiceDate As DateTime

        <Display(name:="Numero Provvisorio")> _
        Property InvoiceNumber As String

        <Display(name:="Numero righe")> _
        Property RowCount As Integer

    End Class

End Namespace
