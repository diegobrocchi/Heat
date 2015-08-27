Imports Heat.Repositories
Imports Heat.Models
Imports Heat.ViewModels.Invoices
Imports System.Linq
Imports System.Data.Entity

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

            d = _db.DocumentTypes.Include(Function(x) x.numbering).Where(Function(dt) dt.Name = "FTC").FirstOrDefault

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

            d = _db.DocumentTypes.Include(Function(x) x.Numbering).Where(Function(dt) dt.Name = "FTC").FirstOrDefault

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

        ''' <summary>
        ''' Recupera la lista delle righe di tipo 'Prodotto' e le righe di tipo 'Descrittiva' 
        ''' e compone una lista di righe fattura di tipo 'Presentazione'.
        ''' </summary>
        ''' <param name="invoiceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInvoiceRows(invoiceID As Integer) As List(Of PresentationInvoiceRowViewModel)
            Dim result As New List(Of PresentationInvoiceRowViewModel)

            Dim productRowList As List(Of ProductInvoiceRow)
            productRowList = _db.ProductInvoiceRows.Include(Function(x) x.Product).Where(Function(x) x.Invoice.ID = invoiceID).ToList

            Dim descriptiveRowList As List(Of DescriptiveInvoiceRow)
            descriptiveRowList = _db.DescriptiveInvoiceRows.Where(Function(x) x.Invoice.ID = invoiceID).ToList


            result.AddRange(productRowList.Select(Function(x) New PresentationInvoiceRowViewModel With {
                       .ID = x.ID,
                       .Item = x.ItemOrder,
                       .InvoiceID = x.Invoice.ID,
                       .SKU = x.Product.SKU,
                       .Product = x.Product.Description,
                       .Quantity = x.Quantity,
                       .UnitPrice = x.UnitPrice,
                       .Discount1 = x.RateDiscount1,
                       .Discount2 = x.RateDiscount2,
                       .Discount3 = x.RateDiscount3,
                       .VAT = x.VAT_Rate,
                       .TotalBeforeTax = x.DiscountedAmount,
                       .Total = x.TotalAmount,
                       .RowType = InvoiceRowType.ProductRow}).
                 ToList())

            result.AddRange(descriptiveRowList.Select(Function(x) New PresentationInvoiceRowViewModel With {
                                                                 .ID = x.ID,
                                                                 .Item = x.ItemOrder,
                                                                 .InvoiceID = x.Invoice.ID,
                                                                 .SKU = String.Empty,
                                                                 .Product = x.RowDescription,
                                                                 .Quantity = x.Quantity,
                                                                 .UnitPrice = x.UnitPrice,
                                                                 .Discount1 = x.RateDiscount1,
                                                                 .Discount2 = x.RateDiscount2,
                                                                 .Discount3 = x.RateDiscount3,
                                                                 .VAT = x.VAT_Rate,
                                                                 .TotalBeforeTax = x.DiscountedAmount,
                                                                 .Total = x.TotalAmount,
                                                                 .RowType = InvoiceRowType.DescriptiveRow}).ToList)
            Return result.OrderBy(Function(x) x.Item).ToList
            

        End Function
    End Class
End Namespace

