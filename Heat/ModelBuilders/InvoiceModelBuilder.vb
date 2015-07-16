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
    Public Function GetConfirmedInvoicesIndexViewModel() As ViewModels.Invoices.confirmedIndexViewModel
        Dim result As New ViewModels.Invoices.confirmedIndexViewModel

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
    Public Function GetInsertedInvoicesIndexViewModel() As ViewModels.Invoices.insertedIndexViewModel
        Dim result As New ViewModels.Invoices.insertedIndexViewModel

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

    Public Function GetInvoiceCreateViewModel(tempDOc As Invoice) As InvoiceCreateViewModel
        Dim result As New InvoiceCreateViewModel
        Dim nm As NumeratorManager = NumeratorManager.Instance

        result.EmissionDate = Now
        result.TempNumber = tempDOc.InsertedNumber

        'result.TempNumber = nm.GetNextTemp(d.Numbering).SerialInteger
        Return result


    End Function


End Class
