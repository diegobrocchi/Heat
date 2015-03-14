Imports Heat.Models

Namespace Business

    Public Class CustomerBusiness



        Public Function GetPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As List(Of Customer)
            Using db = New HeatDBContext

                Return db.Customers.OrderBy(Function(customer) customer.Name).Skip(skip).Take(take).ToList

            End Using


        End Function

    End Class

End Namespace
