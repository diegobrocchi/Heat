Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.PlantServices
    Public Class CreatePlantServiceViewModel

        Property PlantID As Integer

        <Display(name:="Impianto di riferimento")> _
        Property PlantDescription As String

        <Display(name:="Data dell'ultima manutenzione eseguita")> _
        Property PreviousServiceDate As Nullable(Of DateTime)

        <Display(name:="Periodicità della manutenzione")> _
        Property Periodicity As Periodicity

        <Display(name:="Scadenza legale della manutenzione")> _
        Property LegalExpirationDate As DateTime

        <Display(name:="Data programmata della prossima manutenzione")> _
        Property PlannedServiceDate As DateTime

    End Class
End Namespace

