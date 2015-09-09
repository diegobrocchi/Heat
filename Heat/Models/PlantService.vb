Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    ''' <summary>
    ''' Rappresenta la situazione della manutenzione per l'impianto. E' la rappresentazione dello stato di manutenzione. 
    ''' Esiste un solo PlantService per un Plant. 1 Plant ha 0 o 1 PlantService.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PlantService

        <Key, ForeignKey("Plant")> _
        Property ID As Integer

        Property PlantID As Integer
        Property Plant As Plant

        ''' <summary>
        ''' Data della ultima manutenzione eseguita.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PreviousServiceDate As Nullable(Of DateTime)

        ''' <summary>
        ''' Periodicità della manutenzione.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Periodicity As Periodicity

        ''' <summary>
        ''' Scadenza legale della manutenzione.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property LegalExpirationDate As DateTime

        ''' <summary>
        ''' Data programmata di esecuzione della manutenzione. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PlannedServiceDate As DateTime

    End Class
End Namespace

