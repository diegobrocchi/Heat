Imports Heat.Models
Imports Heat.Repositories

Namespace Manager

    Public Class CustomerManager

        Private _db As IHeatDBContext
        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        Public Function GetPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As List(Of Customer)

            Return _db.Customers.OrderBy(Function(customer) customer.Name).Skip(skip).Take(take).ToList

        End Function

        Public Sub EnableCustomer(customer As Customer)
            Me.EnableCustomer(customer.ID)
        End Sub

        Public Sub EnableCustomer(customerID As Integer)
            Dim c As Customer
            c = _db.Customers.Find(customerID)
            If IsNothing(c) Then
                Throw New Exception("Impossibile trovare il Cliente richiesto!")
            End If

            c.IsEnabled = True
            c.EnableDate = Now

        End Sub

        Public Sub DisableCustomer(customer As Customer)
            Me.DisableCustomer(customer.ID)
        End Sub

        Public Sub DisableCustomer(customerID As Integer)
            Dim c As Customer
            c = _db.Customers.Find(customerID)
            If IsNothing(c) Then
                Throw New Exception("Impossibile trovare il Cliente richiesto!")
            End If

            c.IsEnabled = False
            c.DisableDate = Now
        End Sub
    End Class

End Namespace
