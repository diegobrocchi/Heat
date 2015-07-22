Public Class ValidationRules
    Inherits List(Of IValidator)

    Public ReadOnly Property IsValid() As Boolean
        Get
            Return Not IsNothing(Me) AndAlso Me.All(Function(x) x.IsValid)
        End Get
    End Property

    Public ReadOnly Property Errors As List(Of IValidator)
        Get
            Return Me.Where(Function(x) Not x.IsValid).ToList
        End Get
    End Property

End Class