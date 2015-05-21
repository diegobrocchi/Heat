Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class Numbering

        Property ID As Integer
        Property Code As String
        Property Description As String
        Property TempSerialSchemaID As Integer
        Overridable Property TempSerialSchema As SerialScheme
        Property FinalSerialSchemaID As Integer
        Overridable Property FinalSerialSchema As SerialScheme
        Property LastTempSerial As SerialNumber
        Property LastFinalSerial As SerialNumber

    End Class
End Namespace
