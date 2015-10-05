Imports Heat.Models

Namespace Manager
    ''' <summary>
    ''' Il gestore delle chiamate ai contatti.
    ''' </summary>
    Public Class OutboundCallManager

        Private _db As IHeatDBContext

        Public Sub New(dbContext As IHeatDBContext)
            _db = dbContext
        End Sub

        Public Function GetNextOutboundCallSet(login As String) As Integer
            Dim plantList As List(Of Plant)
            plantList = _db.Plants.Where(Function(x) x.Service.LegalExpirationDate <= Now And Now < x.Service.LegalExpirationDate.AddDays(30)).ToList

            Return 0
        End Function
    End Class
End Namespace
