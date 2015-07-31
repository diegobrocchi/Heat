Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Customers
    Public Class DisableCustomerViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String


    End Class
End Namespace

