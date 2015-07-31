
Imports Heat.Models
Imports Heat.ViewModels.Customers

Public Class CustomerModelViewBuilder

    Private _db As IHeatDBContext

    Public Sub New(db As IHeatDBContext)
        _db = db
    End Sub

    Public Function GetDisableCustomerViewModel(id As Integer) As DisableCustomerViewModel
        Dim result As New DisableCustomerViewModel
        Dim c As Customer

        c = _db.Customers.Find(id)
        result.ID = c.ID
        result.CustomerName = c.Name

        Return result

    End Function

End Class
