Namespace Models
    ''' <summary>
    ''' Rappresenta una caldaia
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Boiler
        Property ID As Integer
        Property Manifacturer As Manifacturer
        Property Model As ManifacturerModel
        Property SerialNumber As String
        Property InstallationDate As DateTime
        Property FirstStartUp As DateTime
        Property Warranty As String
        Property WarrantyExpiration As DateTime

        ''' <summary>
        ''' Elenco delle operazioni di manutenzione eseguite sulla caldaia. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Services As List(Of BoilerService)

    End Class
End Namespace
