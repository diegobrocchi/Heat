Imports Heat.Models
Imports Heat.Viewmodels
Imports Heat.Manager

''' <summary>
''' Create models for managing Invoices
''' </summary>
''' <remarks></remarks>
Public Class InvoiceModelBuilder

    Private _db As Global.Heat.Repositories.HeatDBContext

    Public Sub New(repository As Global.Heat.Repositories.HeatDBContext)
        _db = repository
    End Sub

    Public Function GetInvoiceCreateViewModel(tempDOc As Invoice) As InvoiceCreateViewModel
        Dim result As New InvoiceCreateViewModel
        Dim nm As NumeratorManager = NumeratorManager.Instance


        result.EmissionDate = Now
        result.TempNumber = tempDOc.InsertedNumber

        'result.TempNumber = nm.GetNextTemp(d.Numbering).SerialInteger
        Return result


    End Function


End Class
