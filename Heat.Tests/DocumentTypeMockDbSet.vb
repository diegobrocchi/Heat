Imports Heat.Models

Public Class DocumentTypeMockDbSet
    Inherits TestDbSet(Of DocumentType)
    Public Overrides Function Find(ParamArray keyValues() As Object) As DocumentType
        Return Me.SingleOrDefault(Function(x) x.ID = CInt(keyValues.[Single]()))
    End Function

End Class
