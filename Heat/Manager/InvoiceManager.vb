Imports Heat.Repositories
Imports Heat.Models
Namespace Manager
    Public Class InvoiceManager
        Private _db As IHeatDBContext

        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        Public Sub Insert(invoice As Invoice)
            _db.Invoices.Add(invoice)
        End Sub
    End Class
End Namespace

