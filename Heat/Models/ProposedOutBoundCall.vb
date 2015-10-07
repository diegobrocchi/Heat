Namespace Models

    ''' <summary>
    ''' Rappresenta una chiamata per il rinnovo di una manutenzione in scadenza
    ''' </summary>
    Public Class ProposedOutBoundCall

        Property ID As Integer
        Property User As String
        Property PlantID As Integer
        Property Plant As Plant
        Property Contacts As List(Of Contact)

    End Class
End Namespace
