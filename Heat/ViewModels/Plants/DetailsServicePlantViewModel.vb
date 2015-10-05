Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Plants

    Public Class DetailsServicePlantViewModel

        Property ID As Integer

        Property PlantID As Integer


        <Display(Name:="Data ultima manutenzione eseguita")>
        <DisplayFormat(DataFormatString:="{0:d}")>
        Property PreviousServiceDate As Nullable(Of DateTime)

        <Display(Name:="Periodicità")>
        Property Periodicity As Periodicity

        <Display(Name:="Scadenza")>
        <DisplayFormat(DataFormatString:="{0:d}")>
        Property LegalExpirationDate As DateTime

        <Display(Name:="Data programmata della manutenzione")>
        <DisplayFormat(DataFormatString:="{0:d}")>
        Property PlannedServiceDate As DateTime
    End Class
End Namespace
