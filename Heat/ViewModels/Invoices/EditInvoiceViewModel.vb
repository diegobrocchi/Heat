﻿Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Invoices
    Public Class EditInvoiceViewModel
        <Key> _
        Property ID As Integer

        <Display(name:="Cliente")> _
        Property CustomerName As String

        <Display(name:="Numero documento")> _
        Property InvoiceNumber As String

        <Display(name:="Data documento")> _
        Property InvoiceDate As String

        Property Rows As List(Of PresentationInvoiceRowViewModel)


    End Class
End Namespace

