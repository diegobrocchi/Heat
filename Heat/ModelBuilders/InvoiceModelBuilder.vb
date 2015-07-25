Imports Heat.Models
Imports Heat.Viewmodels
Imports Heat.Manager

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

        result.ID = tempDoc.ID
        result.CustomerName = tempDoc.Customer.Name
        result.InvoiceNumber = tempDoc.InsertedNumber.SerialString
        result.InvoiceDate = tempDoc.InvoiceDate.ToShortDateString
        result.Rows = _db.InvoiceRows.
            Where(Function(r) r.Invoice.ID = tempDoc.ID).
            OrderBy(Function(x) x.ItemOrder).
            Select(Function(x) New InvoiceRowViewModel With {
                       .ID = x.ID,
                       .Item = x.ItemOrder,
                       .InvoiceID = x.Invoice.ID,
                       .Product = x.Product.Description,
                       .Quantity = x.Quantity,
                       .UnitPrice = x.UnitPrice}).
               ToList

        Return result


    End Function

    Public Function GetAddInvoiceRowViewModel(invoiceID As Integer) As AddNewInvoiceRowViewModel
        Dim result As New AddNewInvoiceRowViewModel

        result.InvoiceID = invoiceID
        result.ProductList = _db.Products.ToList.OrderBy(Function(x) x.Description).ToSelectListItems(Function(p) p.Description, Function(p) p.ID, "")


        Return result

    End Function


End Class
