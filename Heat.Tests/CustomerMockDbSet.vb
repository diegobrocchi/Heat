Imports Heat.Models

Public Class CustomerMockDbSet
    Inherits TestDbSet(Of Customer)

    Public Overrides Function Find(ParamArray keyValues() As Object) As Customer
        Return Me.SingleOrDefault(Function(x) x.ID = CInt(keyValues.[Single]()))
    End Function

End Class
