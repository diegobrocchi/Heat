Imports Heat.Models

Namespace ViewModels.Invoices
    ''' <summary>
    ''' Modello per la visualizzazione dell'elenco delle fatture in stato CONFERMATO.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class confirmedIndexViewModel
        ''' <summary>
        ''' Stato dei documenti.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property State As DocumentState

        ''' <summary>
        ''' Conteggio delle fatture in stato INSERITO.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property InsertedInvoiceCount As Integer

        ''' <summary>
        ''' Lista delle fatture CONFERMATE.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ConfirmedInvoiceList As List(Of confirmedInvoicesGridViewModel)

    End Class
End Namespace

