Imports System.ComponentModel.DataAnnotations

Namespace ViewModels
    Public Class CustomerViewModel
        Property ID As Integer
        <Display(name:="Nome")> _
        Property Name As String

        <Display(name:="Indirizzo")> _
        Property Address As String

        <Display(name:="Telefono")> _
        Property Telephone As String
    End Class
End Namespace

