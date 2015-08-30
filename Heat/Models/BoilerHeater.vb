Namespace Models
    ''' <summary>
    ''' Rappresenta un bruciatore della caldaia; può essere l'unico bruciatore o uno dei tanti bruciatori.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BoilerHeater
        Property ID As Integer
        Property Boiler As Boiler
        Property Manifacturer As Manifacturer
        Property Model As ManifacturerModel
        Property SerialNumber As String
        Property MinimumPowerKW As Single
        Property MaximumPowerKW As Single
        Property CertificationReference As String

    End Class
End Namespace
