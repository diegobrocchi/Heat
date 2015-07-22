Imports Heat.Models

Public Class EditableInvoiceValidator
    Implements IValidator

    Dim _db As IHeatDBContext
    Dim _invoiceID As Integer

    Public Sub New(repository As IHeatDBContext, invoiceID As Integer)
        _db = repository
        _invoiceID = invoiceID
    End Sub

    Public ReadOnly Property ErrorMessage As String Implements IValidator.ErrorMessage
        Get
            Return "Il documento non è modificabile"
        End Get
    End Property

    Public ReadOnly Property IsValid As Boolean Implements IValidator.IsValid
        Get
            Return _db.Invoices.Find(_invoiceID).State = DocumentState.Inserted
        End Get
    End Property
End Class
