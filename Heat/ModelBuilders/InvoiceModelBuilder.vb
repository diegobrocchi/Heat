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

    Public Function GetConfirmedInvoicesIndexViewModel() As ViewModels.Invoices.indexViewModel
        Dim result As New ViewModels.Invoices.indexViewModel

        result.State = DocumentState.Inserted
        result.InvoiceList = _db.Invoices.
            Where(Function(x) x.State = DocumentState.Inserted).Select(
                Function(x) New Invoices.InvoicesGridViewModel With {
                    .ID = x.ID,
                    .Customer = x.Customer.Name,
                    .InvoiceDate = x.InvoiceDate,
                    .InvoiceNumber = x.ConfirmedNumber.SerialString,
                    .Total = x.TotalAmount}).ToList
        Return result
    End Function

    Public Function GetInsertedInvoicesIndexViewModel() As ViewModels.Invoices.indexViewModel
        Dim result As New ViewModels.Invoices.indexViewModel

        result.State = DocumentState.Inserted
        result.InvoiceList = _db.Invoices.Where(Function(x) x.State = DocumentState.Inserted).Select(
            Function(x) New Invoices.InvoicesGridViewModel With {
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
