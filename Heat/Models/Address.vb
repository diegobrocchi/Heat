﻿Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class Address
        <Key> _
        Property ID As Integer
        Property AddressTypeID As Integer
        Property AddressType As AddressType
        Property Street As String
        Property StreetNumber As String
        Property City As String
        Property PostalCode As String
        Property District As String
        Property State As String
        Property Note As String

        'Property CustomerID As Nullable(Of Integer)
        'Overridable Property Customer As Customer


    End Class
End Namespace
