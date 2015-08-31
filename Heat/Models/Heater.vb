
Namespace Models

    ''' <summary>
    ''' Rappresenta un bruciatore della caldaia; può essere l'unico bruciatore o uno dei tanti bruciatori.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Heater
        Property ID As Integer
        Property ThermalUnit As ThermalUnit
        Property Manifacturer As Manifacturer
        Property Model As ManifacturerModel
        Property SerialNumber As String
        Property MinimumPowerKW As Single
        Property MaximumPowerKW As Single
        Property CertificationReference As String

    End Class
End Namespace

