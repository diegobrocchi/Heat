Namespace Models

    ''' <summary>
    ''' Rappresenta un Modello di caldaia per il Produttore
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ManifacturerModel
        Property ID As Integer
        Property ManifacturerID As Integer
        Property Manifacturer As manifacturer
        Property Model As String
        Property Services As List(Of BoilerService)

    End Class
End Namespace
