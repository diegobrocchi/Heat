Imports Heat.Models

Namespace Manager
    ''' <summary>
    ''' Il gestore delle chiamate ai contatti.
    ''' </summary>
    Public Class OutboundCallsManager

        Private _db As IHeatDBContext

        Public Sub New(dbContext As IHeatDBContext)
            _db = dbContext
        End Sub

        ''' <summary>
        ''' Genera una lista di chiamate da effettuare.
        ''' Le chiamate sono relative agli impianti con la manutenzione scaduta o in scadenza.
        ''' Genera una lista diversa per ogni utente.
        ''' </summary>
        ''' <param name="login"></param>
        ''' <returns></returns>
        Public Function GetNextOutboundCallSet(login As String) As List(Of ProposedOutBoundCall)
            Dim result As New List(Of ProposedOutBoundCall)
            Dim expiringServicePlants As List(Of Plant)

            'cerca gli impianti con la manutenzione scaduta o in scadenza nei prossimi 30 giorni
            'esclude gli impianti che abbiano una data di manutenzione fissata nel futuro
            Dim stopDate As Date = Now.AddDays(30)
            expiringServicePlants = _db.Plants.Where(Function(x) x.Service.LegalExpirationDate <= stopDate And x.Service.PlannedServiceDate < Now).ToList

            'esclude quelli per i quali sono già assegnate chiamate
            Dim pendingCallPlants As List(Of Plant)
            pendingCallPlants = expiringServicePlants.Except(_db.ProposedOutboundCalls.Select(Function(x) x.Plant).ToList).ToList

            result = pendingCallPlants.Select(Function(x) New ProposedOutBoundCall With {.Plant = x, .Contacts = x.Contacts, .PlantID = x.ID, .User = login}).ToList

            Return result

        End Function
    End Class
End Namespace
