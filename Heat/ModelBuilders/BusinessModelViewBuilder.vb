Imports Heat.Models
Imports Heat.Manager

Public Class BusinessModelViewBuilder
    Private _db As IHeatDBContext

    Public Sub New(context As IHeatDBContext)
        _db = context
    End Sub

    'Public Function GetSortedAndPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As IList(Of Customer)
    '    Dim cbl As New CustomerManager(_db)

    '    Return cbl.GetPagedCustomer(sortOrder, skip, take)

    'End Function

End Class
