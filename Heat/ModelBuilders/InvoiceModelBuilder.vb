Imports Heat.Models
Imports Heat.Viewmodels
Imports Heat.Manager

''' <summary>
''' Create models for managing Invoices
''' </summary>
''' <remarks></remarks>
Public Class InvoiceModelBuilder

    Private db As Heat.Repositories.HeatDBContext

    Public Sub New(repository As Heat.Repositories.HeatDBContext)
        db = repository
    End Sub

    Public Function GetInvoiceCreateViewModel(customer As Customer) As InvoiceCreateViewModel
        Dim result As New InvoiceCreateViewModel

        result.Customer = customer
        result.EmissionDate = Now
        Dim d As DocumentType
        d = From doc In db.DocumentTypes Where doc.Name = "FTC"
        result.TempNumber = NumeratorManager.GetNext(d.Numbering)








    End Function


End Class
