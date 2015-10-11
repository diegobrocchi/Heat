Imports Heat.ViewModels.OutboundCall
Imports Heat.Manager

''' <summary>
''' Costruisce tutti i modelli per le View
''' </summary>
Public Class OutboundCallsModelViewBuilder
    Private _db As IHeatDBContext
    Private _ocm As Outboundcallsmanager

    Public Sub New(dbContext As IHeatDBContext)
        _db = dbContext
        _ocm = New OutboundCallsManager(_db)
    End Sub

    Public Function GetNextProposed(login As String) As ProposedOutboundCallsViewModel
        Dim result As New ProposedOutboundCallsViewModel

        result.User = login

        Return result

    End Function
End Class
