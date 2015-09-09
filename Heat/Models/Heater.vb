
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

        Property InstallationDate As DateTime
        Property Type As String

        Property FuelID As Integer
        Property Fuel As Fuel

        Property DismissDate As Nullable(Of DateTime)

    End Class
End Namespace

