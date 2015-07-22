Imports Heat.Repositories
Imports Heat.Models
Namespace Manager
    Public Class InvoiceManager
        Private _db As IHeatDBContext

        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        ''' <summary>
        ''' Prepara una fattura temporanea per il cliente indicato
        ''' </summary>
        ''' <param name="customerID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTemporaryDocument(customerID) As Invoice
            Dim result As New Invoice
            Dim numberGenerator As NumeratorManager = NumeratorManager.Instance
            Dim d As DocumentType


            d = _db.DocumentTypes.Include("Numbering").Where(Function(dt) dt.Name = "FTC").FirstOrDefault
            
            result.Customer = _db.Customers.Find(customerID)
            result.InvoiceDate = DateTime.Now
            result.InsertedNumber = numberGenerator.GetNextTemp(d.Numbering)
            result.ConfirmedNumber = New SerialNumber
            _db.Invoices.Add(result)

            Return result
        End Function
        Public Sub Insert(invoice As Invoice)
            _db.Invoices.Add(invoice)
        End Sub
    End Class
End Namespace

