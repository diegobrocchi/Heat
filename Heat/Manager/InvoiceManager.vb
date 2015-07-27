Imports Heat.Repositories
Imports Heat.Models
Namespace Manager
    ''' <summary>
    ''' Gestisce le regole di business per la fatturazione.
    ''' </summary>
    ''' <remarks></remarks>
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
            result.IsTaxExempt = False
            'result.Payment = 

            _db.Invoices.Add(result)

            Return result
        End Function

        ''' <summary>
        ''' Conferma il documento con ID specificato.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetConfirmedDocument(id As Integer) As Boolean
            Dim invoice As New Invoice
            Dim rows As List(Of InvoiceRow)

            Dim numberGenerator As NumeratorManager = NumeratorManager.Instance
            Dim d As DocumentType

            d = _db.DocumentTypes.Include("Numbering").Where(Function(dt) dt.Name = "FTC").FirstOrDefault

            invoice = _db.Invoices.Include("InvoiceRows").Where(Function(x) x.ID = id).First
            rows = invoice.InvoiceRows


            invoice.InvoiceDate = DateTime.Now
            invoice.ConfirmedNumber = numberGenerator.GetNextFinal(d.Numbering)
            invoice.State = DocumentState.Confirmed
            invoice.TaxableAmount = rows.Sum(Function(x) x.DiscountedAmount)
            invoice.TaxesAmount = rows.Sum(Function(x) x.TaxAmount)
            invoice.TotalAmount = invoice.TaxableAmount + invoice.TaxesAmount

            Return True

        End Function

        Public Sub Insert(invoice As Invoice)
            _db.Invoices.Add(invoice)
        End Sub
    End Class
End Namespace

