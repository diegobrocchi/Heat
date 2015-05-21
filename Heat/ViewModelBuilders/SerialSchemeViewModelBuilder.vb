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

    Public Function getListViewModel() As List(Of IndexSerialSchemeViewModel)
        Dim result As New List(Of IndexSerialSchemeViewModel)

        Dim l As New List(Of SerialScheme)
        l = _db.SerialSchemes.ToList

        result = Mapper.Map(Of List(Of SerialScheme), List(Of IndexSerialSchemeViewModel))(l)

        Return result


    End Function

End Class
