Namespace Models

    ''' <summary>
    ''' Rappresenta una chiamata per il rinnovo di una manutenzione in scadenza
    ''' </summary>
    Public Class ProposedOutBoundCall

        Property ID As Integer
        ''' <summary>
        ''' L'utente a cui è stata proposta la chiamata.
        ''' </summary>
        ''' <returns></returns>
        Property User As String
        Property PlantID As Integer
        Property Plant As Plant
        Property Contacts As List(Of Contact)

    End Class
End Namespace
