Imports Heat.Models
Imports Heat.Viewmodels
Imports Heat.Manager
Imports System.Data.Entity

''' <summary>
''' Create models for managing Invoices
''' </summary>
''' <remarks></remarks>
Public Class InvoiceModelBuilder

    Private _db As Global.Heat.Repositories.HeatDBContext

    Public Sub New(repository As IHeatDBContext)
        _db = repository
    End Sub

    ''' <summary>
    ''' Prepara il modello da visualizzare nella view con l'elenco delle fatture confermate.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConfirmedInvoicesIndexViewModel() As Viewmodels.Invoices.confirmedIndexViewModel
        Dim result As New Viewmodels.Invoices.confirmedIndexViewModel

        result.State = DocumentState.Confirmed
        result.InsertedInvoiceCount = _db.Invoices.Where(Function(x) x.State = DocumentState.Inserted).Count

        result.ConfirmedInvoiceList = _db.Invoices.
            Where(Function(x) x.State = DocumentState.Confirmed).Select(
                Function(x) New Invoices.confirmedInvoicesGridViewModel With {
                    .ID = x.ID,
                    .Customer = x.Customer.Name,
                    .InvoiceDate = x.InvoiceDate,
                    .InvoiceNumber = x.ConfirmedNumber.SerialString,
                    .Total = x.TotalAmount}).ToList

        Return result
    End Function

    ''' <summary>
    ''' Prepara il modello per la view con l'elenco delle fatture INSERITE (ma non ancora confermate).
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetInsertedInvoicesIndexViewModel() As Viewmodels.Invoices.insertedIndexViewModel
        Dim result As New Viewmodels.Invoices.insertedIndexViewModel

        result.State = DocumentState.Inserted
        result.InsertedInvoiceList = _db.Invoices.Where(Function(x) x.State = DocumentState.Inserted).Select(
            Function(x) New Invoices.InsertedInvoicesGridViewModel With {
                .ID = x.ID,
                .Customer = x.Customer.Name,
                .InvoiceDate = x.InvoiceDate,
                .InvoiceNumber = x.InsertedNumber.SerialString,
                .Total = x.TotalAmount}).ToList

        Return result
    End Function


    Public Function GetEditInvoiceViewModel(tempDoc As Invoice) As EditInvoiceViewModel
        Dim result As New EditInvoiceViewModel
        Dim dbRowList As New List(Of InvoiceRow)

        result.ID = tempDoc.ID
        result.CustomerName = tempDoc.Customer.Name
        result.InvoiceNumber = tempDoc.InsertedNumber.SerialString
        result.InvoiceDate = tempDoc.InvoiceDate.ToShortDateString

        dbRowList = _db.InvoiceRows.Include("Product").
            Where(Function(r) r.Invoice.ID = tempDoc.ID).
            OrderBy(Function(x) x.ItemOrder).ToList

        result.Rows = dbRowList.Select(Function(x) New InvoiceRowViewModel With {
                       .ID = x.ID,
                       .Item = x.ItemOrder,
                       .InvoiceID = x.Invoice.ID,
                       .Product = x.Product.Description,
                       .Quantity = x.Quantity,
                       .UnitPrice = x.UnitPrice,
                       .Discount1 = x.RateDiscount1,
                       .Discount2 = x.RateDiscount2,
                       .Discount3 = x.RateDiscount3,
                                .TotalBeforeTax = x.DiscountedAmount,
                                .Total = x.TotalAmount}).
                 ToList()

        Return result


    End Function


    ''' <summary>
    ''' Produce il modello di rigaFattura per la vista Create. 
    ''' </summary>
    ''' <param name="invoiceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAddInvoiceRowViewModel(invoiceID As Integer) As AddNewInvoiceRowViewModel
        Dim result As New AddNewInvoiceRowViewModel

        result.InvoiceID = invoiceID
        result.ProductList = _db.Products.ToList.OrderBy(Function(x) x.Description).ToSelectListItems(Function(p) p.Description, Function(p) p.ID, "")
        result.VAT = 22

        Return result

    End Function

    ''' <summary>
    ''' Produce il modello per la view in cui si scelgono le condizioni di pagamento per la fattura.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getEditInvoicePaymentViewModel(id As Integer) As InvoicePaymentViewModel
        Dim result As New InvoicePaymentViewModel
        Dim dbInvoice As Invoice
        Dim rows As List(Of InvoiceRow)

        dbInvoice = _db.Invoices.Where(Function(x) x.ID = id).
            Include(Function(x) x.Customer).
            Include(Function(x) x.InvoiceRows).
            Include(Function(x) x.Payment).Include(Function(x) x.InvoiceRows.Select(Function(r) r.Product)).FirstOrDefault()

        rows = dbInvoice.InvoiceRows

        result.ID = id
        result.CustomerName = dbInvoice.Customer.Name
        result.InvoiceNumber = dbInvoice.InsertedNumber.SerialString
        result.InvoiceDate = dbInvoice.InvoiceDate.ToShortDateString
        result.IsTaxExempt = dbInvoice.IsTaxExempt
        result.Rows = rows.Select(Function(x) New InvoiceRowViewModel With {
                       .ID = x.ID,
                       .Item = x.ItemOrder,
                       .InvoiceID = x.Invoice.ID,
                       .Product = x.Product.Description,
                       .Quantity = x.Quantity,
                       .UnitPrice = x.UnitPrice,
                       .Discount1 = x.RateDiscount1,
                       .Discount2 = x.RateDiscount2,
                       .Discount3 = x.RateDiscount3,
                                .TotalBeforeTax = x.DiscountedAmount,
                                .Total = x.TotalAmount}).
                 ToList()

        If Not dbInvoice.Payment Is Nothing Then
            result.PaymentID = dbInvoice.Payment.ID
        End If
        result.PaymentList = _db.Payments.ToList.ToSelectListItems(Function(x) x.Description, Function(x) x.ID, result.PaymentID)
        result.TaxExemption = dbInvoice.TaxExemption

        Return result

    End Function

End Class
