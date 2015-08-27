Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Customers
    Public Class EnableCustomerViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Data di disabilitazione")> _
        Property DisableDate As DateTime

    End Class
End Namespace

