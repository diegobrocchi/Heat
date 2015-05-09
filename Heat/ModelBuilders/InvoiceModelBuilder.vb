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

    Public Function GetInvoiceCreateViewModel(customer As Customer) As InvoiceCreateViewModel
        Dim result As New InvoiceCreateViewModel
        Dim nm As NumeratorManager = NumeratorManager.Instance

        result.Customer = customer
        result.EmissionDate = Now
        Dim d As DocumentType
        d = From doc In _db.DocumentTypes Where doc.Name = "FTC"
        result.TempNumber = nm.GetNextTemp(d.Numbering).SerialInteger



    End Function


End Class
