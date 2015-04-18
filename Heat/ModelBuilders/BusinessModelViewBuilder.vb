Imports Heat.Models
Imports Heat.Manager

Public Class BusinessModelViewBuilder

    Public Function GetSortedAndPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As IList(Of Customer)
        Dim cbl As New CustomerManager

        Return cbl.GetPagedCustomer(sortOrder, skip, take)

    End Function

End Class
