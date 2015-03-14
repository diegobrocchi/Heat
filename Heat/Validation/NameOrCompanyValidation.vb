Imports System.ComponentModel.DataAnnotations

''' <summary>
''' Inmpone che la proprietà sia valorizzata se un'altra è nulla.
''' </summary>
''' <remarks></remarks>
Public Class RequiredIfEmpty
    Inherits ValidationAttribute

    Private _other As String
    ''' <summary>
    ''' La proprietà di cui deve essere controllata la presenza per validare la corrente.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Other() As String
        Get
            Return _other
        End Get
        Private Set(ByVal value As String)
            _other = value
        End Set
    End Property



    Public Sub New(other As String)
        _other = other
    End Sub

    Protected Overrides Function IsValid(value As Object, validationContext As ValidationContext) As ValidationResult

        'se il valore della proprietà non è nullo allora è valido.
        If Not IsNothing(value) Then
            Return ValidationResult.Success
        Else
            'se il valore è nullo allora non deve essere nullo quello dell'altra proprietà.
            Dim pi = validationContext.ObjectType.GetProperty(Other)
            If Not IsNothing(pi) Then
                If String.IsNullOrEmpty(pi.GetValue(validationContext.ObjectInstance)) Then
                    Return New ValidationResult(String.Format("Questo valore è richiesto se {0} è nullo", Other))
                Else
                    Return ValidationResult.Success
                End If
            Else
                Return New ValidationResult(String.Format("Non esiste la proprietà {0}", Other))
            End If

        End If
    End Function

End Class
