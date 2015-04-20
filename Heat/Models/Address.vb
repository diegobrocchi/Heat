﻿Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class Address
        <Key> _
        Property ID As Integer
        Property AddressType As AddressType
        Property Street As String
        Property StreetNumber As String
        Property City As String
        Property PostalCode As String
        Property Province As String
        Property State As String
        Property Phone As String
        Property CellPhone As String
        Property Fax As String
        Property Note As String

    End Class
End Namespace