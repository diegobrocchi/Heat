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

    End Class

End Namespace
