Imports Heat.Models
Imports System.ComponentModel.DataAnnotations

Namespace ViewModels

    ''' <summary>
    ''' Modello 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class InvoiceCreateViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Numero documento")> _
        Property TempNumber As String

        <Display(name:="Data emissione")> _
        Property EmissionDate As Date


    End Class

End Namespace

