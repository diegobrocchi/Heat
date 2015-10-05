Namespace Models
    ''' <summary>
    ''' Rappresenta una chiamata ad un contatto per fissare un appuntamento.
    ''' </summary>
    Public Class OutboundCall
        Property ID As Integer
        Property CallDate As DateTime
        Property ContactID As Integer
        Overridable Property Contact As Contact
        Property ResultID As Integer

        ''' <summary>
        ''' Chi ha eseguito la chiamata
        ''' </summary>
        ''' <returns></returns>
        Property Login As String
    End Class
End Namespace
