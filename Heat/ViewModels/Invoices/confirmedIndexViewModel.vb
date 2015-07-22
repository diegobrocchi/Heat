Imports Heat.Models

Namespace ViewModels.Invoices
    Public Class confirmedIndexViewModel
        Property State As DocumentState
        Property InsertedInvoiceCount As Integer
        Property ConfirmedInvoiceList As List(Of confirmedInvoicesGridViewModel)

    End Class
End Namespace

