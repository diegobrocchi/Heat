Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Customers
    Public Class IndexCustomerGridViewModel
        <Key> _
        Property ID As Integer
        <Required> _
        <Display(name:="Nome")> _
        Property Name As String
        <Display(name:="Indirizzo")> _
        Property Address As String
        <Display(name:="Città")> _
        Property City As String
        <Display(Name:="CAP")> _
        Property PostalCode As String
        <Display(name:="Provincia")> _
        Property District As String

        <Display(name:="Telefono 1")> _
        Property Telephone1 As String
        <Display(name:="Telefono 2")> _
        Property Telephone2 As String
        <Display(name:="Telefono 3")> _
        Property Telephone3 As String
        <Display(name:="Codice fiscale")> _
        Property Taxcode As String
        <Display(name:="Partita IVA")> _
        Property VAT_Number As String
        <Display(name:="IBAN")> _
        Property IBAN As String

        <EmailAddress> _
        Property EMail As String
        <Url> _
        Property Website As String

        Property IsEnabled As Boolean
        Property CreationDate As DateTime
        Property EnableDate As Nullable(Of DateTime)
        Property DisableDate As Nullable(Of DateTime)
    End Class
End Namespace

