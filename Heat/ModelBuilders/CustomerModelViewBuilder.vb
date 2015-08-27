
Imports Heat.Models
Imports Heat.ViewModels.Customers
Imports AutoMapper

Public Class CustomerModelViewBuilder

    Private _db As IHeatDBContext

    Public Sub New(db As IHeatDBContext)
        _db = db
    End Sub

    Public Function GetIndexCustomerViewModel(includeDisabled As Boolean) As IndexCustomerViewModel
        Dim result As New IndexCustomerViewModel
        Dim customerList As List(Of Customer)

        If includeDisabled Then
            customerList = _db.Customers.OrderBy(Function(c) c.Name).ToList
            result.IsIncludeDisable = True
        Else
            customerList = _db.Customers.Where(Function(c) c.IsEnabled = True).OrderBy(Function(c) c.Name).ToList
            result.IsIncludeDisable = False
        End If

        result.HasDisabled = _db.Customers.Where(Function(c) c.IsEnabled = False).Count > 0
        result.Rows = Mapper.Map(Of List(Of IndexCustomerGridViewModel))(customerList)

        Return result

    End Function

    Public Function GetDisableCustomerViewModel(id As Integer) As DisableCustomerViewModel
        Dim result As New DisableCustomerViewModel
        Dim c As Customer

        c = _db.Customers.Find(id)
        result.ID = c.ID
        result.CustomerName = c.Name

        Return result

    End Function

    Public Function GetEnableCustomerViewModel(id As Integer) As EnableCustomerViewModel
        Dim result As New EnableCustomerViewModel
        Dim c As Customer
        c = _db.Customers.Find(id)

        result.ID = c.ID
        result.CustomerName = c.Name
        result.DisableDate = c.DisableDate

        Return result
    End Function
    Public Function GetEditCustomerViewModel(id As Integer) As EditCustomerViewModel
        Dim result As New EditCustomerViewModel
        Dim editingItem As Customer

        editingItem = _db.Customers.Find(id)

        result = Mapper.Map(Of EditCustomerViewModel)(editingItem)

        Return result
    End Function

End Class
