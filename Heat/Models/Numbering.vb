Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class Numbering

        Property ID As Integer
        Property Code As String
        Property Description As String
        Property TempSerialSchema As SerialScheme
        Property FinalSerialSchema As SerialScheme
        Property LastTempSerial As SerialNumber
        Property LastFinalSerial As SerialNumber

    End Class
End Namespace
