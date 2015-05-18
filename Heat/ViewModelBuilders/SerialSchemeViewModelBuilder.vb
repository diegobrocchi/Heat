Imports Heat.Models
Imports AutoMapper

Public Class SerialSchemeViewModelBuilder

    Private _db As IHeatDBContext

    Public Sub New(context As IHeatDBContext)
        If IsNothing(context) Then
            Throw New Exception("Context!")
        End If

        _db = context
    End Sub

    Public Function getListViewModel() As List(Of SerialSchemeViewModel)
        Dim result As New List(Of SerialSchemeViewModel)

        Dim l As New List(Of SerialScheme)
        l = _db.SerialSchemes.ToList

        result = Mapper.Map(Of List(Of SerialScheme), List(Of SerialSchemeViewModel))(l)

        Return result


    End Function

End Class
